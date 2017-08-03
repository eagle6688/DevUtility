(function ($, window, document, undefined) {
    var pluginName = 'koHelper',
        version = 'v4.0.20170712';

    var defaults = {
        url: '',
        requestType: 'GET',
        requestData: null,
        viewModel: null,
        selectAllBtn: '#cb-selectAll',
        selectItemsSelector: 'tbody input[type="checkbox"]',
        pageSize: 10,
        noDataDom: '', //Dom displays when there is no datum loaded.
        loadingDom: '', //Dom displays when data are loading.
        beforeLoadData: function (data) { },
        afterLoadData: function (data) { }
    };

    function Plugin(element, options) {
        this.element = element;
        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);
        this._init();
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._init = function () {
        this._initData();
        this._initKo();
        this._register();
        this._loadData();
    };

    Plugin.prototype._initData = function () {
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

    Plugin.prototype._register = function () {
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

    Plugin.prototype._registerSelectItems = function () {
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

    Plugin.prototype._loadData = function () {
        if (this.options.viewModel) {
            this._setViewModel(this.options.viewModel);
        }
        else if (this.options.url) {
            this._requestData();
        }
    };

    Plugin.prototype._requestData = function () {
        var self = this;
        var url = getPageUrl(this.options.url, this.pageIndex, this.options.pageSize);

        this._ajax(url, function (data) {
            self._setViewModel(data);
        });
    };

    Plugin.prototype._setViewModel = function (data) {
        this._beforeLoadData(data);
        this.viewModel.Count(data.Count);
        this.viewModel.Data(data.Data);
        this._afterLoadData(data);
    };

    Plugin.prototype._beforeLoadData = function (data) {
        if (this.options.beforeLoadData) {
            this.options.beforeLoadData(data);
        }
    };

    Plugin.prototype._afterLoadData = function (data) {
        this._registerSelectItems();

        if (this.options.afterLoadData) {
            this.options.afterLoadData(data);
        }
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

    //exported methods

    Plugin.prototype.changePage = function (pageIndex, pageSize) {
        this.pageIndex = pageIndex;

        if (pageSize) {
            this.options.pageSize = pageSize;
        }

        this._requestData();
    };

    Plugin.prototype.reload = function (options) {
        this.pageIndex = 1;
        this.options = $.extend(true, {}, this.options, options);
        this._loadData();
    };

    Plugin.prototype.reloadPost = function (options) {
        options = options || {};
        options.requestType = 'POST';
        this.reload(options);
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