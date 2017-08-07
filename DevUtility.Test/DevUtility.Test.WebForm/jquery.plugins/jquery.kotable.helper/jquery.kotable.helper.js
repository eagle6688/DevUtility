(function ($, window, document, undefined) {
    var pluginName = 'koTableHelper',
        version = 'v4.0.20170807';

    var defaults = {
        anchorPointSelector: '',
        ko: {
            selector: '',
            options: null
        },
        pagination: {
            selector: '',
            options: null
        },
        mobilepagination: {
            selector: '',
            options: null
        }
    };

    function Plugin(options) {
        this.options = $.extend(true, {}, defaults, options);
        this._init();
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._init = function () {
        this.$ko = null;
        this.$pagination = null;
        this.$mobilepagination = null;

        this._initKo();
        this._initPagination();
        this._initMobilePagination();
    };

    Plugin.prototype._initKo = function () {
        var self = this,
            options = {},
            beforeLoadData = null;

        if (!self.options.ko || !self.options.ko.selector) {
            return;
        }

        if (self.options.ko.options && self.options.ko.options.beforeLoadData) {
            beforeLoadData = self.options.ko.options.beforeLoadData;
        }

        options.beforeLoadData = function (data) {
            if (beforeLoadData) {
                beforeLoadData(data);
            }

            if (self.$pagination) {
                self.$pagination.data('pagination').changeTotalRecords(data.Count);
            }

            if (self.$mobilepagination) {
                self.$mobilepagination.data('paginationmobile').changeTotalRecords(data.Count);
            }
        };

        this.options.ko.options = $.extend(true, {}, this.options.ko.options, options);
        this.$ko = $(this.options.ko.selector).koHelper(this.options.ko.options);
    };

    Plugin.prototype._initPagination = function () {
        var self = this,
            options = {},
            onPageClick = null;

        if (!self.options.pagination || !self.options.pagination.selector) {
            return;
        }

        if (self.options.pagination.options && self.options.pagination.options.onPageClick) {
            onPageClick = self.options.pagination.options.onPageClick;
        }

        options.onPageClick = function (pageIndex) {
            if (onPageClick) {
                onPageClick(pageIndex);
            }

            if (self.$mobilepagination) {
                self.$mobilepagination.data('paginationmobile').changePageIndex(pageIndex);
            }

            if (self.$ko) {
                self.$ko.data('koHelper').changePage(pageIndex);
            }

            self.gotoAnchorPoint();
        };

        this.options.pagination.options = $.extend(true, {}, this.options.pagination.options, options);
        this.$pagination = $(this.options.pagination.selector).pagination(this.options.pagination.options);
    };

    Plugin.prototype._initMobilePagination = function () {
        var self = this,
            options = {},
            onPageClick = null;

        if (!self.options.mobilepagination || !self.options.mobilepagination.selector) {
            return;
        }

        if (self.options.mobilepagination.options && self.options.mobilepagination.options.onPageClick) {
            onPageClick = self.options.mobilepagination.options.onPageClick;
        }

        options.onPageClick = function (pageIndex) {
            if (onPageClick) {
                onPageClick(pageIndex);
            }

            if (self.$pagination) {
                self.$pagination.data('pagination').changePageIndex(pageIndex);
            }

            if (self.$ko) {
                self.$ko.data('koHelper').changePage(pageIndex);
            }

            self.gotoAnchorPoint();
        };

        this.options.mobilepagination.options = $.extend(true, {}, this.options.mobilepagination.options, options);
        this.$mobilepagination = $(this.options.mobilepagination.selector).paginationmobile(this.options.mobilepagination.options);
    };

    Plugin.prototype.gotoAnchorPoint = function () {
        if (this.options.anchorPointSelector && $(this.options.anchorPointSelector).length > 0) {
            $(this.options.anchorPointSelector)[0].scrollIntoView();
        }
    };

    $[pluginName] = function (options) {
        return new Plugin(options);
    };
})(jQuery, window, document);