;
(function ($, window, document, undefined) {
    var pluginName = 'koHelper',
        version = 'v1.0.20161119';

    var defaults = {
        url: '', //request url，required
        pk: 'ID', //Primary key
        requestType: 'GET',
        requestData: null,
        paginationID: 'pagination', //paging control id
        checkAllID: 'cb_selectAll', //id of 'select all' button
        oddTrClass: '',
        noneDataDom: '', //Dom displays when there is no datum loaded.
        loadingDom: '', //Dom displays when data are loading.
        validateData: null, //Validating data before display them.
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
        this.initPagination();
        this.initData();
        this.requestServer(this.paginationOptions.pageIndex);
        this.register();
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

    Plugin.prototype.initPagination = function () {
        var that = this;
        this.$pagination = $('#' + that.options.paginationID);
        this.paginationOptions = $.extend({}, $.pagination.getDefaults(), that.options.paginationOptions);
        var onPageClick = this.paginationOptions.onPageClick;

        this.paginationOptions.onPageClick = function (pageIndex) {
            if (onPageClick) {
                onPageClick(pageIndex);
            }

            that.requestServer(pageIndex);
        };
    };

    Plugin.prototype.initData = function () {
        this.viewModel = {
            Url: '',
            Data: ko.observableArray([]),
            RecordsCount: ko.observable(0)
        };

        ko.applyBindings(this.viewModel, this.element);
    };

    Plugin.prototype.clearData = function () {
        this.loadData(0, [], 1);
    };

    Plugin.prototype.reLoad = function (url, pageIndex, requestType) {
        if (url) {
            this.options.url = url;
        }

        if (!pageIndex || pageIndex < 1) {
            pageIndex = 1;
        }

        if (requestType) {
            this.options.requestType = requestType;
        }

        this.requestServer(pageIndex);
    };

    Plugin.prototype.requestServer = function (pageIndex) {
        var that = this;
        this.viewModel.Url = getRequestUrl(this.options.url, pageIndex, this.options.paginationOptions.pageSize);
        displayDom(this.options.loadingDom, true);

        this.httpRequest(function (data) {
            if (that.validateData(data)) {
                that.isValidData = true;
            }
            else {
                that.isValidData = false;
                return;
            }

            displayDom(that.options.loadingDom, false);

            if (data && data.Count > 0 && data.Data) {
                that.loadData(data.Count, data.Data, pageIndex);
            }
            else {
                that.loadData(0, [], 1);
            }

            if (that.options.afterLoadData) {
                that.options.afterLoadData();
            }
        });
    };

    Plugin.prototype.validateData = function (data) {
        if (!this.options.validateData) {
            return true;
        }

        if (!this.options.validateData(data)) {
            this.clearData();
            displayDom(this.options.loadingDom, false);
            return false;
        }

        return true;
    };

    Plugin.prototype.loadData = function (count, data, pageIndex) {
        this.loadPagination(count, pageIndex);
        this.displayData(count, data);
    };

    Plugin.prototype.loadPagination = function (count, pageIndex) {
        this.paginationOptions.pageIndex = pageIndex;
        this.paginationOptions.totalRecords = count;
        this.$pagination.pagination(this.paginationOptions);
    };

    Plugin.prototype.displayData = function (count, data) {
        this.viewModel.RecordsCount(count);
        this.viewModel.Data(data);

        if (count > 0) {
            this.$element.show();
            displayDom(this.options.paginationID, true);
            displayDom(this.options.noneDataDom, false);
            this.setTrStyles();
        }
        else {
            this.$element.hide();
            displayDom(this.options.paginationID, false);

            if (!this.isValidData) {
                fadeDom(this.options.noneDataDom, 3000);
            }
        }
    };

    Plugin.prototype.setTrStyles = function () {
        if (this.options.oddTrClass) {
            this.$element.find('tbody tr:odd').addClass(this.options.oddTrClass);
        }
    };

    Plugin.prototype.getRecordsCount = function () {
        return this.viewModel.RecordsCount();
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
            dataType: 'text',
            type: this.options.requestType,
            data: this.options.requestData,
            cache: false,
            success: function (data) {
                if (succeeded) {
                    succeeded($.parseJSON(data));
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