;
(function ($, window, document, undefined) {
    var pluginName = 'koHelper',
        version = '20170409';

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
        validateData: null, //Validating data before display them.
        beforeLoadData: null,
        afterLoadData: null,
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

            that.requestServer(pageIndex);
        };

        this.pagination = $pagination.pagination(this.paginationOptions).data('pagination');
    };

    Plugin.prototype.initData = function () {
        if (!this.options.viewModel) {
            this.requestServer(this.paginationOptions.pageIndex);
            return;
        }

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

    Plugin.prototype.clearData = function () {
        this.displayData(0, [], 1);
    };

    Plugin.prototype.reLoad = function (url, pageIndex) {
        this.options.requestType = 'GET';

        if (url && typeof (url) === 'string') {
            this.options.url = url;
        }

        if (!pageIndex || pageIndex < 1) {
            pageIndex = 1;
        }

        this.requestServer(pageIndex);
    };

    Plugin.prototype.reLoadPost = function (options) {
        var defaults = {
            url: '',
            data: '',
            success: function (data) { }
        };

        this.options.requestType = 'POST';
        this.reLoadConfig = $.extend(true, {}, defaults, options);

        if (this.reLoadConfig.url) {
            this.options.url = this.reLoadConfig.url;
        }

        if (this.reLoadConfig.data) {
            this.options.requestData = this.reLoadConfig.data;
        }

        this.requestServer(1);
    };

    Plugin.prototype.requestServer = function (pageIndex) {
        var that = this;
        this.viewModel.Url = getRequestUrl(this.options.url, pageIndex, this.options.paginationOptions.pageSize);
        displayDom(this.options.loadingDom, true);

        this.httpRequest(function (data) {
            that.applyData(data, pageIndex);
        });
    };

    Plugin.prototype.applyData = function (data, pageIndex) {
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

        displayDom(this.options.loadingDom, false);

        if (data && data.Count > 0 && data.Data) {
            this.displayData(data.Count, data.Data, pageIndex);
        }
        else {
            this.displayData(0, [], 1);
        }

        if (this.options.afterLoadData) {
            this.options.afterLoadData(data);
        }
    };

    Plugin.prototype.verifyData = function (data) {
        if (!this.options.validateData) {
            return true;
        }

        if (!this.options.validateData(data)) {
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

    Plugin.prototype.httpRequest = function (succeeded) {
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

    function getRequestUrl(baseUrl, pageIndex, pageSize) {
        var url = baseUrl;
        var skip = (pageIndex - 1) * pageSize;

        if (baseUrl.indexOf('?') > 0) {
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

    var fadeDom = function (id, times) {
        if (!id) return;

        if (!times) {
            times = 3000;
        }

        $('#' + id).fadeIn(times);
        $('#' + id).fadeOut(times);
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