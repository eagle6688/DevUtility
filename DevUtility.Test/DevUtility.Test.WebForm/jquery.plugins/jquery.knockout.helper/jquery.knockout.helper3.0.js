;
(function ($, window, document, undefined) {
    var pluginName = 'koHelper',
        version = 'v3.0.20170728';

    var defaults = {
        url: '', //request url，required
        requestType: 'GET',
        requestData: null,
        viewModel: null,
        pk: 'ID', //Primary key
        paginationID: 'pagination', //paging control id
        checkAllID: 'cb_selectAll', //id of 'select all' button
        oddTrClass: '',
        noneDataDom: '', //Dom displays when there is no datum loaded.
        loadingDom: '', //Dom displays when data are loading.
        verifyData: function (data) { return true }, //Verify data before display them.
        beforeLoadData: function (data) { },
        afterLoadData: function (data) { },
        paginationOptions: {
            pageSize: 10,
            pageIndex: 1
        }
    };

    function Plugin(element, options) {
        this.element = element;
        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);
        this.init();
    };

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype.init = function () {
        this.initViewModel();
        this.initPagination();
        this.initData();
        this.register();
    };

    Plugin.prototype.initViewModel = function () {
        var defaults = {
            Url: '',
            Data: ko.observableArray([]),
            Count: ko.observable(0)
        };

        this.viewModel = $.extend(true, {}, this.options.viewModel, defaults);
        ko.applyBindings(this.viewModel, this.element);
    };

    Plugin.prototype.initPagination = function () {
        var that = this;
        var $pagination = $('#' + this.options.paginationID);
        this.paginationOptions = $.extend({}, $.pagination.getDefaults(), this.options.paginationOptions);
        var onPageClick = this.paginationOptions.onPageClick;

        this.paginationOptions.onPageClick = function (pageIndex) {
            if (onPageClick) {
                onPageClick(pageIndex);
            }

            that.loadData(pageIndex);
        };

        this.pagination = $pagination.pagination(this.paginationOptions).data('pagination');
    };

    Plugin.prototype.initData = function () {
        if (this.options.viewModel) {
            this._initDataWithData();
            return;
        }

        this.loadData(this.paginationOptions.pageIndex);
    };

    Plugin.prototype._initDataWithData = function () {
        this.beforeLoadData(this.options.viewModel);
        var count = this.options.viewModel.Count;
        var data = this.options.viewModel.Data;

        if (count > 0 && data && data.length > 0) {
            this.displayData(count, data, this.paginationOptions.pageIndex);
        }
    };

    Plugin.prototype.register = function () {
        var that = this;

        $('#' + this.options.checkAllID).click(function () {
            var $selectAll = $(this);

            if ($selectAll.is(':checked')) {
                that.$element.find('tbody input[type="checkbox"][name="cb_list"]').prop('checked', true);
            }
            else {
                that.$element.find('tbody input[type="checkbox"][name="cb_list"]').prop('checked', false);
            }
        });
    };

    Plugin.prototype.getRequestData = function () {
        return this.options.requestData;
    };

    Plugin.prototype.setRequestData = function (requestData) {
        this.options.requestData = requestData;
    };

    Plugin.prototype.reload = function (options) {
        var defaults = {
            url: '',
            type: 'GET',
            data: null,
            viewModel: null,
            pageIndex: 1
        };

        var config = $.extend(true, {}, defaults, options);

        if (config.url) {
            this.options.url = config.url;
        }

        if (config.type) {
            this.options.requestType = config.type;
        }

        if (config.data) {
            this.options.requestData = config.data;
        }

        if (!config.pageIndex || config.pageIndex < 1) {
            config.pageIndex = 1;
        }

        if (config.viewModel) {
            this.beforeLoadData(config.viewModel);
            this.applyData(config.viewModel, config.pageIndex);
        }
        else {
            this.loadData(config.pageIndex);
        }
    };

    Plugin.prototype.reloadPost = function (options) {
        options.type = 'POST';
        this.reload(options);
    };

    Plugin.prototype.reloadWithData = function (data) {
        this.reload({ viewModel: data });
    };

    Plugin.prototype.loadData = function (pageIndex) {
        var that = this;
        this.viewModel.Url = this.getRequestUrl(pageIndex);
        displayDom(this.options.loadingDom, true);

        this.ajax(function (data) {
            that.beforeLoadData(data);
            that.applyData(data, pageIndex);
            displayDom(that.options.loadingDom, false);
        });
    };

    Plugin.prototype.beforeLoadData = function (data) {
        if (this.verifyData(data)) {
            this.isValidData = true;
        }
        else {
            this.isValidData = false;
            return;
        }

        if (this.options.beforeLoadData) {
            this.options.beforeLoadData(data);
        }
    };

    Plugin.prototype.applyData = function (data, pageIndex) {
        if (data && data.Count > 0 && data.Data) {
            this.displayData(data.Count, data.Data, pageIndex);
        }
        else {
            this.clearData();
        }

        if (this.options.afterLoadData) {
            this.options.afterLoadData(data);
        }
    };

    Plugin.prototype.verifyData = function (data) {
        if (!this.options.verifyData) {
            return true;
        }

        if (!this.options.verifyData(data)) {
            this.clearData();
            return false;
        }

        return true;
    };

    Plugin.prototype.displayData = function (count, data, pageIndex) {
        this.displayList(count, data);
        this.displayPagination(count, pageIndex);
    };

    Plugin.prototype.displayList = function (count, data) {
        if (count > 0 && data) {
            this.$element.show();
            displayDom(this.options.noneDataDom, false);
        }
        else {
            this.$element.hide();
            displayDom(this.options.noneDataDom, true);
        }

        this.viewModel.Count(count);
        this.viewModel.Data(data);
        this.setTrStyles();
    };

    Plugin.prototype.displayPagination = function (count, pageIndex) {
        this.pagination.reLoad(count, pageIndex);
    };

    Plugin.prototype.setTrStyles = function () {
        if (this.options.oddTrClass) {
            this.$element.find('tbody tr:odd').addClass(this.options.oddTrClass);
        }
    };

    Plugin.prototype.getRecordsCount = function () {
        return this.viewModel.Count();
    };

    Plugin.prototype.getSelectedItems = function () {
        var array = new Array();

        this.$element.find('tbody input[type="checkbox"][name="cb_list"]').each(function () {
            var $checkbox = $(this);

            if ($checkbox.is(':checked')) {
                var pk = parseInt($checkbox.attr('value'));
                array.push(pk);
            }
        });

        return array;
    };

    Plugin.prototype.clearData = function () {
        this.displayData(0, [], 1);
    };

    Plugin.prototype.ajax = function (succeeded) {
        $.ajax({
            url: this.viewModel.Url,
            dataType: 'json',
            type: this.options.requestType,
            data: this.options.requestData,
            cache: false,
            success: function (data) {
                if (succeeded) {
                    succeeded(data);
                }
            }
        });
    };

    Plugin.prototype.getRequestUrl = function (pageIndex) {
        var url = this.options.url;
        var pageSize = this.options.paginationOptions.pageSize;
        var skip = (pageIndex - 1) * pageSize;

        if (url.indexOf('?') > 0) {
            url += '&';
        }
        else {
            url += '?';
        }

        url += 'pageIndex=' + pageIndex;
        url += '&pageSize=' + pageSize;
        url += '&skip=' + skip;
        return url;
    };

    var displayDom = function (id, isDisplay) {
        if (!id) return;

        if (isDisplay) {
            $('#' + id).show();
        }
        else {
            $('#' + id).hide();
        }
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);