(function ($, window, document, undefined) {
    var pluginName = 'pagination',
        version = 'v3.0.20170731';

    var defaults = {
        totalRecords: 0,
        pageIndex: 1,
        pageSize: 10,
        visiblePagesCount: 7, //Visible pages count.
        changingType: 'ajax', //Changing page can cause two action types 'jump' and 'ajax'.
        firstButtonName: 'First', //Text of 'first' button.
        firstButtonClass: 'first', //Style of 'first' button.
        preButtonName: 'Previous', //Button's text of Previous button.
        preButtonClass: 'prev', //Button's style of Previous.
        nextButtonName: 'Next', //Button's text of Next.
        nextButtonClass: 'next', //Button's style of Next.
        lastButtonName: 'Last', //Button's text of Last.
        lastButtonClass: 'last', //Button's style of Last.
        disabledButtonClass: 'disabled', //Style of disabled button.
        currentButtonClass: 'active', //Style of current button.
        paginationClass: 'pagination pagination-sm', //Style of ul dom.
        onPageClick: function (pageIndex) { },
        afterPageClick: function (pageIndex) { },
        onReload: function (recordsCount, pageIndex, pageSize) { }
    };

    function Plugin(element, options) {
        this.$element = $(element).empty();
        this.options = $.extend({}, defaults, options);

        if (this._verify()) {
            this._init();
        }
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._verify = function () {
        if (!this._verifyParameter()) {
            console.error('Parameter error!');
            return false;
        }

        return true;
    };

    Plugin.prototype._verifyParameter = function () {
        var options = this.options;

        if (isNaN(options.totalRecords) || options.totalRecords < 0) {
            return false;
        }

        if (isNaN(options.pageIndex) || options.pageIndex < 1) {
            return false;
        }

        if (isNaN(options.pageSize) || options.pageSize < 1) {
            return false;
        }

        if (isNaN(options.visiblePagesCount) || options.visiblePagesCount < 1) {
            return false;
        }

        return true;
    };

    Plugin.prototype._init = function () {
        this.currentPage = this.options.pageIndex;
        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);
        this.displayPagesCount = getDisplayPagesCount(this.pagesCount, this.options.visiblePagesCount);
        this._initPagination();
    };

    Plugin.prototype._initPagination = function () {
        this.$pagination = $('<ul></ul>');

        if (this.options.paginationClass) {
            this.$pagination.addClass(this.options.paginationClass);
        }

        this._fillPagination();
        this.$element.append(this.$pagination);
    };

    Plugin.prototype._fillPagination = function () {
        this.$firstBtn = this._createButton(this.options.firstButtonName, this.options.firstButtonClass);
        this.$prevBtn = this._createButton(this.options.preButtonName, this.options.preButtonClass);

        this.$nextBtn = this._createButton(this.options.nextButtonName, this.options.nextButtonClass);
        this.$lastBtn = this._createButton(this.options.lastButtonName, this.options.lastButtonClass);
        this.$pagination.append(this.$firstBtn, this.$prevBtn, this.$nextBtn, this.$lastBtn);
    };

    Plugin.prototype._createButton = function (text, liClass) {
        if (text === null || text === '' || text === undefined) {
            return null;
        }

        var $button = $('<li></li>');

        if (liClass) {
            $button.addClass(liClass);
        }

        return $button.append($('<a href="javascript:void(0);"></a>').html(text));
    };

    Plugin.prototype._createPageButtons = function (start, end) {

    };

    var calculatePagesCount = function (totalRecords, pageSize) {
        var count = parseInt(totalRecords / pageSize);

        if (totalRecords % pageSize > 0) {
            count++;
        }

        return count;
    };

    var getDisplayPagesCount = function (pagesCount, visiblePagesCount) {
        return Math.min(pagesCount, visiblePagesCount);
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);