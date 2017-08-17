(function ($, window, document, undefined) {
    var pluginName = 'paginationmobile',
        version = '20170809';

    var defaults = {
        totalRecords: 0,
        pageSize: 10,
        pageIndex: 1,
        pageTextFormat: 'Page {pageIndex}',
        pageIndexPattern: '{pageIndex}',
        firstBtnText: '&lt;&lt;',
        firstBtnClass: 'first',
        prevBtnText: '&lt;',
        prevBtnClass: 'prev',
        nextBtnText: '&gt;',
        nextBtnClass: 'next',
        lastBtnText: '&gt;&gt;',
        lastBtnClass: 'last',
        paginationClass: 'ul-pager',
        disabledBtnClass: 'disabled',
        canEditPageIndex: true,
        onPageClick: function (pageIndex) { },
        onReload: function (options) { },
        onError: function (pageIndex, message) { }
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

        if (isNaN(options.pageSize) || options.pageSize < 1) {
            return false;
        }

        if (isNaN(options.pageIndex) || options.pageIndex < 1) {
            return false;
        }

        return true;
    };

    Plugin.prototype._init = function () {
        this.buttonTypeName = 'buttonType';
        this._initPagination();
    };

    Plugin.prototype._initPagination = function () {
        this.$pagination = $('<ul></ul>');
        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);
        this.options.pageIndex = Math.min(this.options.pageIndex, Math.max(1, this.pagesCount));

        if (this.options.paginationClass) {
            this.$pagination.addClass(this.options.paginationClass);
        }

        this._fillPagination();
        this._bind();
        this.$element.empty().append(this.$pagination);
    };

    Plugin.prototype._fillPagination = function () {
        this.$firstBtn = createButton(this.options.firstBtnText, this.options.firstBtnClass);
        this.$prevBtn = createButton(this.options.prevBtnText, this.options.prevBtnClass);
        this.$pageBtn = createPageButton(this._getPageText(), this.options.pageIndex);
        this.$nextBtn = createButton(this.options.nextBtnText, this.options.nextBtnClass);
        this.$lastBtn = createButton(this.options.lastBtnText, this.options.lastBtnClass);
        this.$pagination.append(this.$firstBtn, this.$prevBtn, this.$pageBtn, this.$nextBtn, this.$lastBtn);
    };

    Plugin.prototype._bind = function () {
        this._bindFirstButton();
        this._bindPrevButton();
        this._bindNextButton();
        this._bindLastButton();
        this._bindPageButton();
    };

    Plugin.prototype._bindFirstButton = function () {
        var self = this;
        var $button = this.$firstBtn;

        if ($button === null) {
            return;
        }

        $button.unbind('click');

        if (this.options.pageIndex === 1) {
            $button.addClass(this.options.disabledBtnClass);
        }
        else {
            $button.removeClass(this.options.disabledBtnClass);

            $button.click(function () {
                self._changePage(1);
            });
        }
    };

    Plugin.prototype._bindPrevButton = function () {
        var self = this;
        var $button = this.$prevBtn;

        if ($button === null) {
            return;
        }

        $button.unbind('click');

        if (this.options.pageIndex === 1) {
            $button.addClass(this.options.disabledBtnClass);
        }
        else {
            $button.removeClass(this.options.disabledBtnClass);

            $button.click(function () {
                self._changePage(self.options.pageIndex - 1);
            });
        }
    };

    Plugin.prototype._bindNextButton = function () {
        var self = this;
        var $button = this.$nextBtn;

        if ($button === null) {
            return;
        }

        $button.unbind('click');

        if (this.options.pageIndex === this.pagesCount || this.pagesCount === 0) {
            $button.addClass(this.options.disabledBtnClass);
        }
        else {
            $button.removeClass(this.options.disabledBtnClass);

            $button.click(function () {
                self._changePage(self.options.pageIndex + 1);
            });
        }
    };

    Plugin.prototype._bindLastButton = function () {
        var self = this;
        var $button = this.$lastBtn;

        if ($button === null) {
            return;
        }

        $button.unbind('click');

        if (this.options.pageIndex === this.pagesCount || this.pagesCount === 0) {
            $button.addClass(this.options.disabledBtnClass);
        }
        else {
            $button.removeClass(this.options.disabledBtnClass);

            $button.click(function () {
                self._changePage(self.pagesCount);
            });
        }
    };

    Plugin.prototype._bindPageButton = function () {
        var self = this;
        var $button = this.$pageBtn;

        if (!this.options.canEditPageIndex) {
            return;
        }

        $button.children('.show-page').unbind('click').click(function () {
            $button.children(':text').removeClass('hidden').focus();
            $(this).addClass('hidden');
        });

        $button.children(':text').unbind('blur').blur(function () {
            $(this).addClass('hidden');
            $button.children('.show-page').removeClass('hidden');

            if (!self._inputPageIndex($(this).val())) {
                $(this).val(self.options.pageIndex);
            }
        });
    };

    Plugin.prototype._getPageText = function () {
        var regExp = new RegExp(this.options.pageIndexPattern, 'g');
        return this.options.pageTextFormat.replace(regExp, this.options.pageIndex);
    };

    Plugin.prototype._inputPageIndex = function (input) {
        if (!input || isNaN(input)) {
            return false;
        }

        var pageIndex = parseInt(input);

        if (pageIndex < 1 || pageIndex > this.pagesCount) {
            return false;
        }

        this._changePage(pageIndex);
        return true;
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

    Plugin.prototype._changePage = function (pageIndex) {
        if ((this.pagesCount > 0 && pageIndex > this.pagesCount) || pageIndex < 0) {
            this._error(pageIndex, 'Invalid page index!');
            return;
        }

        this.options.pageIndex = pageIndex;
        setPageText(this.$pageBtn, this._getPageText(), pageIndex);
        this._bind();

        if (this.options.onPageClick) {
            this.options.onPageClick(pageIndex);
        }
    };

    Plugin.prototype._onReload = function () {
        if (this.options.onReload) {
            this.options.onReload(this.options);
        }
    };

    Plugin.prototype._error = function (pageIndex, message) {
        if (this.options.onError) {
            this.options.onError(pageIndex, message);
        }

        console.error(message);
    };

    //inner functions

    var calculatePagesCount = function (totalRecords, pageSize) {
        var count = parseInt(totalRecords / pageSize);

        if (totalRecords % pageSize > 0) {
            count++;
        }

        return count;
    };

    var createButton = function (text, liClass) {
        if (!text) {
            return null;
        }

        var $button = $('<li></li>');

        if (liClass) {
            $button.addClass(liClass);
        }

        return $button.append($('<a href="javascript:void(0);"></a>').html(text));
    };

    var createPageButton = function (text, pageIndex) {
        var $button = $('<li class="page"></li>');
        $button.append($('<div class="show-page"></div>').html(text));
        $button.append($('<input type="text" value="" class="hidden" />').val(pageIndex));
        return $button;
    };

    var setPageText = function ($button, text, pageIndex) {
        $button.children('.show-page').html(text);
        $button.children(':text').val(pageIndex);
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
        switch (arguments.length) {
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

        this._initPagination();
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