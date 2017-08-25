(function ($, window, document, undefined) {
    var pluginName = 'koHelper',
        version = 'v4.0.20170825';

    var defaults = {
        url: '',
        requestType: 'GET',
        requestData: null,
        viewModel: null,
        selectAllBtn: '#cb-selectAll',
        selectItemsSelector: 'tbody input[type="checkbox"]',
        pageSize: 10,
        autoLoad: true,
        loadingDom: '', //Dom displays when data are loading.
        beforeLoadData: function (data) { },
        afterLoadData: function (data) { },
        onReload: function (data) { }
    };

    var events = {
        init: 1,
        reload: 2,
        changePage: 3
    };

    function Plugin(element, options) {
        this.element = element;
        this.$element = $(element);
        this.options = $.extend({}, defaults, options);
        this._init();
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._init = function () {
        this._initData();
        this._initKo();
        this._load();
        this._bind();
    };

    Plugin.prototype._initData = function () {
        this.event = events.init;
        this.pageIndex = 1;
        this.selectedItems = [];

        this.viewModel = {
            Data: ko.observableArray([]),
            Count: ko.observable(0)
        };
    };

    Plugin.prototype._initKo = function () {
        ko.applyBindings(this.viewModel, this.element);
    };

    Plugin.prototype._load = function () {
        if (this.options.autoLoad) {
            this._loadData();
        }
    };

    Plugin.prototype._loadData = function () {
        if (this.options.viewModel) {
            this._setViewModel(this.options.viewModel);
            this.options.viewModel = null;
        }
        else if (this.options.url) {
            this._requestData();
        }
    };

    Plugin.prototype._requestData = function () {
        var self = this;
        var url = getPageUrl(this.options.url, this.pageIndex, this.options.pageSize);
        this._displayDom(this.options.loadingDom);

        this._ajax(url, function (data) {
            self._setViewModel(data);
            self._hideDom(self.options.loadingDom);
        });
    };

    Plugin.prototype._setViewModel = function (data) {
        this._onReload(data);
        this._beforeLoadData(data);
        this.viewModel.Count(data.Count);
        this.viewModel.Data(data.Data);
        this._afterLoadData(data);
    };

    Plugin.prototype._bind = function () {
        var self = this;

        $(this.options.selectAllBtn).click(function () {
            var index = 0;

            if ($(this).is(':checked')) {
                self.$element.find(self.options.selectItemsSelector).prop('checked', true);

                for (index in self.viewModel.Data()) {
                    self._addSelectedItem(self.viewModel.Data()[index]);
                }
            }
            else {
                self.$element.find(self.options.selectItemsSelector).prop('checked', false);

                for (index in self.viewModel.Data()) {
                    self._removeSelectedItem(self.viewModel.Data()[index]);
                }
            }
        });
    };

    Plugin.prototype._bindSelectItems = function () {
        var self = this;

        $(this.options.selectItemsSelector).click(function () {
            var index = $(self.options.selectItemsSelector).index(this);
            var item = self.viewModel.Data()[index];

            if ($(this).is(':checked')) {
                self._addSelectedItem(item);
            }
            else {
                self._removeSelectedItem(item);
            }
        });
    };

    Plugin.prototype._ajax = function (url, success) {
        $.ajax({
            url: url,
            dataType: 'json',
            type: this.options.requestType,
            data: this.options.requestData,
            cache: false,
            success: function (data) {
                if (success) {
                    success(data);
                }
            }
        });
    };

    Plugin.prototype._addSelectedItem = function (item) {
        for (var i = 0; i < this.selectedItems.length; i++) {
            if (this.selectedItems[i] === item) {
                return;
            }
        }

        this.selectedItems.push(item);
    };

    Plugin.prototype._removeSelectedItem = function (item) {
        for (var i = 0; i < this.selectedItems.length; i++) {
            if (this.selectedItems[i] === item) {
                this.selectedItems.splice(i, 1);
                return;
            }
        }
    };

    Plugin.prototype._reloadOptions = function (options) {
        var newOptions = $.extend(true, {}, options);
        this.options = $.extend({}, this.options, newOptions);
    };

    Plugin.prototype._reloadOption = function (name, value) {
        if (this.options.hasOwnProperty(name)) {
            this.options[name] = clone(value);
        }
    };

    Plugin.prototype._displayDom = function (selector) {
        if (selector && $(selector).length > 0) {
            $(selector).show();
        }
    };

    Plugin.prototype._hideDom = function (selector) {
        if (selector && $(selector).length > 0) {
            $(selector).hide();
        }
    };

    //events

    Plugin.prototype._beforeLoadData = function (data) {
        if (this.options.beforeLoadData) {
            this.options.beforeLoadData(data);
        }
    };

    Plugin.prototype._afterLoadData = function (data) {
        this._bindSelectItems();

        if (this.options.afterLoadData) {
            this.options.afterLoadData(data);
        }
    };

    Plugin.prototype._onReload = function (data) {
        if (this.event !== events.init && this.event !== events.reload) {
            return;
        }

        if (this.options.onReload) {
            this.options.onReload(data);
        }
    };

    //inner functions

    var getPageUrl = function (url, pageIndex, pageSize) {
        if (url.indexOf('?') > 0) {
            url += '&';
        }
        else {
            url += '?';
        }

        var skip = (pageIndex - 1) * pageSize;
        url += 'pageIndex=' + pageIndex;
        url += '&pageSize=' + pageSize;
        url += '&skip=' + skip;
        return url;
    };

    var clone = function (value) {
        var obj = {
            value: value
        };

        var newObject = $.extend(true, {}, obj);
        return newObject.value;
    };

    //exported methods

    Plugin.prototype.changePage = function (pageIndex) {
        this.event = events.changePage;
        this.pageIndex = pageIndex;
        this._requestData();
    };

    Plugin.prototype.changePageAndOptions = function (pageIndex, options) {
        if (options) {
            this._reloadOptions(options);
        }

        this.changePage(pageIndex);
    };

    Plugin.prototype.reload = function () {
        this.event = events.reload;

        switch (arguments.length) {
            case 1:
                this._reloadOptions(arguments[0]);
                break;

            case 2:
                this._reloadOption(arguments[0], arguments[1]);
                break;

            default:
                break;
        }

        this.pageIndex = 1;
        this._loadData();
    };

    Plugin.prototype.get = function (name) {
        return this.options[name];
    };

    Plugin.prototype.getSelectedItems = function () {
        return this.selectedItems;
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);