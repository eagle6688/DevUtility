(function ($, window, document, undefined) {
    var pluginName = 'pagination',
        version = 'v3.0.20170817';

    var defaults = {
        totalRecords: 0,
        pageIndex: 1,
        pageSize: 10,
        visiblePagesCount: 7, //Visible pages count.
        changingType: 'ajax', //Changing page can cause two action types 'jump' and 'ajax'.
        firstButtonName: 'First', //Text of 'first' button.
        firstButtonClass: 'first', //Style of 'first' button.
        prevButtonName: 'Previous', //Button's text of Previous button.
        prevButtonClass: 'prev', //Button's style of Previous.
        nextButtonName: 'Next', //Button's text of Next.
        nextButtonClass: 'next', //Button's style of Next.
        lastButtonName: 'Last', //Button's text of Last.
        lastButtonClass: 'last', //Button's style of Last.
        disabledButtonClass: 'disabled', //Style of disabled button.
        currentButtonClass: 'active', //Style of current button.
        paginationClass: 'pagination pagination-sm', //Style of ul dom.
        onPageClick: function (pageIndex) { },
        onReload: function (options) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
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
        this.buttonDataName = 'pageIndex';
        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);
        this.displayPagesCount = getDisplayPagesCount(this.pagesCount, this.options.visiblePagesCount);
        this._initPagination();
    };

    Plugin.prototype._initPagination = function () {
        this.$pagination = $('<ul></ul>');

        if (this.options.paginationClass) {
            this.$pagination.addClass(this.options.paginationClass);
        }

        this._loadPagination();
        this.$element.empty().append(this.$pagination);
    };

    Plugin.prototype._loadPagination = function () {
        this.$pagination.empty();
        this._fillPagination();
        this._bind();
    };

    Plugin.prototype._fillPagination = function () {
        this.$firstBtn = createButton(this.options.firstButtonName, this.options.firstButtonClass);
        this.$prevBtn = createButton(this.options.prevButtonName, this.options.prevButtonClass);
        this.$pagination.append(this.$firstBtn, this.$prevBtn);

        this._fillPageButtons();

        this.$nextBtn = createButton(this.options.nextButtonName, this.options.nextButtonClass);
        this.$lastBtn = createButton(this.options.lastButtonName, this.options.lastButtonClass);
        this.$pagination.append(this.$nextBtn, this.$lastBtn);
    };

    Plugin.prototype._fillPageButtons = function () {
        var pagesRegion = getPagesRegion(this.options.pageIndex, this.displayPagesCount, this.pagesCount);
        this._createPageButtons(pagesRegion.start, pagesRegion.end);
    };

    Plugin.prototype._createPageButtons = function (start, end) {
        for (var i = start; i <= end; i++) {
            var $pageButton = createButton(i).data(this.buttonDataName, i);
            this.$pagination.append($pageButton);
        }
    };

    Plugin.prototype._bind = function () {
        this._bindButtons();
        this._bindPageButtons();
    };

    Plugin.prototype._bindButtons = function () {
        this._bindFirstButton(this.$firstBtn);
        this._bindPrevButton(this.$prevBtn);
        this._bindNextButton(this.$nextBtn);
        this._bindLastButton(this.$lastBtn);
    };

    Plugin.prototype._bindPageButtons = function () {
        var self = this;

        this.$pagination.children('li').each(function () {
            var $button = $(this);
            var data = $button.data(self.buttonDataName);

            if (data) {
                var pageIndex = ~~data;

                if (self.options.pageIndex === pageIndex) {
                    if (!(isButton($button, self.options.firstButtonName) || isButton($button, self.options.lastButtonName))) {
                        $button.addClass(self.options.currentButtonClass);
                    }
                }
                else {
                    $button.click(function () {
                        self._changePage(pageIndex);
                    });
                }
            }
        });
    };

    Plugin.prototype._bindFirstButton = function ($button) {
        var self = this;

        if ($button === null) {
            return;
        }

        if (this.options.pageIndex === 1) {
            $button.addClass(this.options.disabledButtonClass);
        }
        else {
            $button.click(function () {
                self._changePage(1);
            });
        }
    };

    Plugin.prototype._bindPrevButton = function ($button) {
        var self = this;

        if ($button === null) {
            return;
        }

        if (this.options.pageIndex === 1) {
            $button.addClass(this.options.disabledButtonClass);
        }
        else {
            $button.click(function () {
                self._changePage(self.options.pageIndex - 1);
            });
        }
    };

    Plugin.prototype._bindNextButton = function ($button) {
        var self = this;

        if ($button === null) {
            return;
        }

        if (this.options.pageIndex === this.pagesCount || this.pagesCount === 0) {
            $button.addClass(this.options.disabledButtonClass);
        }
        else {
            $button.click(function () {
                self._changePage(self.options.pageIndex + 1);
            });
        }
    };

    Plugin.prototype._bindLastButton = function ($button) {
        var self = this;

        if ($button === null) {
            return;
        }

        if (this.options.pageIndex === this.pagesCount || this.pagesCount === 0) {
            $button.addClass(this.options.disabledButtonClass);
        }
        else {
            $button.click(function () {
                self._changePage(self.pagesCount);
            });
        }
    };

    Plugin.prototype._changePage = function (pageIndex) {
        this.options.pageIndex = pageIndex;
        this._onPageClick(pageIndex);
        this._loadPagination();
    };

    Plugin.prototype._needReloadOptions = function (options) {
        for (var p in options) {
            if (this._needReloadOption(p, options[p])) {
                return true;
            }
        }

        return false;
    };

    Plugin.prototype._needReloadOption = function (name, value) {
        return this.options.hasOwnProperty(name) && this.options[name] !== value;
    };

    Plugin.prototype._reloadOptions = function (options) {
        this.options = $.extend({}, this.options, options);
    };

    Plugin.prototype._reloadOption = function (name, value) {
        this.options[name] = value;
    };

    //events

    Plugin.prototype._onPageClick = function (pageIndex) {
        if (this.options.onPageClick) {
            this.options.onPageClick(pageIndex);
        }
    };

    Plugin.prototype._onReload = function () {
        if (this.options.onReload) {
            this.options.onReload(this.options);
        }
    };

    //inner functions

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

    var getPagesRegion = function (pageIndex, displayPagesCount, pagesCount) {
        var result = {
            start: 0,
            end: 0
        };

        var half = parseInt(displayPagesCount / 2);

        if (pageIndex === 1 || pageIndex <= half) {
            result.start = 1;
            result.end = displayPagesCount;
            return result;
        }

        if (pageIndex === pagesCount || pageIndex >= pagesCount - half) {
            result.start = pagesCount - displayPagesCount + 1;
            result.end = pagesCount;
            return result;
        }

        result.start = pageIndex - half;
        result.end = pageIndex + half;

        if (displayPagesCount % 2 === 0) {
            result.start += 1;
        }

        return result;
    };

    var createButton = function (text, liClass) {
        if (text === null || text === '' || text === undefined) {
            return null;
        }

        var $button = $('<li></li>');

        if (liClass) {
            $button.addClass(liClass);
        }

        return $button.append($('<a href="javascript:void(0);"></a>').html(text));
    };

    var isButton = function ($button, text) {
        return $button.children('a').html() === text;
    };

    //export methods

    Plugin.prototype.changeTotalRecords = function (totalRecords) {
        var options = {
            pageIndex: 1,
            totalRecords: totalRecords
        };

        this.reload(options);
    };

    Plugin.prototype.changePageIndex = function (pageIndex) {
        this.reload('pageIndex', pageIndex);
    };

    Plugin.prototype.reload = function () {
        switch(arguments.length){
            case 1:
                if (this._needReloadOptions(arguments[0])) {
                    this._reloadOptions(arguments[0]);
                }
                break;

            case 2:
                if (this._needReloadOption(arguments[0], arguments[1])) {
                    this._reloadOption(arguments[0], arguments[1]);
                }
                break;

            default:
                break;
        }

        this._init();
        this._onReload();
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);