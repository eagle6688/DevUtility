(function ($, window, document, undefined) {
    var pluginName = 'paginationmobile',
        version = '20170712';

    var defaults = {
        totalRecords: 0,
        pageSize: 10,
        pageIndex: 1,
        pageText: 'Page {pageIndex}',
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
        canInputIndex: true,
        onChangingPage: function (pageIndex) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, defaults, options);

        if (this.verifyParameter()) {
            this.init();
        }
        else {
            console.error("Parameter error!")
        }
    };

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype.verifyParameter = function () {
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

    Plugin.prototype.init = function () {
        this.$element.empty();
        this.registeredFirstButton = false;
        this.registeredPrevButton = false;
        this.registeredNextButton = false;
        this.registeredLastButton = false;

        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);

        if (this.pagesCount > 0) {
            this.currentPageIndex = getCustomPageIndex(this.options.pageIndex, this.pagesCount);
            this.initPagination();
        }
    };

    Plugin.prototype.reLoad = function (recordsCount, pageIndex, pageSize) {
        if (recordsCount) {
            this.options.totalRecords = recordsCount;
        }

        if (pageIndex) {
            this.options.pageIndex = pageIndex;
        }

        if (pageSize) {
            this.options.pageSize = pageSize;
        }

        this.init();
    };

    Plugin.prototype.initPagination = function () {
        var $pagination = $('<ul></ul>');

        if (this.options.paginationClass) {
            $pagination.addClass(this.options.paginationClass);
        }

        this.$firstBtn = this.createButton(this.options.firstBtnText, this.options.firstBtnClass);
        this.$prevBtn = this.createButton(this.options.prevBtnText, this.options.prevBtnClass);
        this.$page = this.createPage();
        this.$nextBtn = this.createButton(this.options.nextBtnText, this.options.nextBtnClass);
        this.$lastBtn = this.createButton(this.options.lastBtnText, this.options.lastBtnClass);
        $pagination.append(this.$firstBtn, this.$prevBtn, this.$page, this.$nextBtn, this.$lastBtn);
        this.register();
        this.$element.append($pagination);
    };

    Plugin.prototype.register = function () {
        this.registerFirstButton();
        this.registerPrevButton();
        this.registerNextButton();
        this.registerLastButton();
    };

    Plugin.prototype.registerFirstButton = function () {
        var self = this;

        if (this.registeredFirstButton) {
            return;
        }

        this.registerButton(this.$firstBtn, function () {
            if (self.currentPageIndex === 1) {
                self.disableButton(self.$firstBtn);
                self.registeredFirstButton = false;
                return;
            }
            
            self.changingPage(1);
        });

        this.registeredFirstButton = true;
    };

    Plugin.prototype.registerPrevButton = function () {
        var self = this;

        if (this.registeredPrevButton) {
            return;
        }

        this.registerButton(this.$prevBtn, function () {
            if (self.currentPageIndex === 1) {
                self.disableButton(self.$prevBtn);
                self.registeredPrevButton = false;
                return;
            }

            self.changingPage(self.currentPageIndex - 1);
        });

        this.registeredPrevButton = true;
    };

    Plugin.prototype.registerNextButton = function () {
        var self = this;

        if (this.registeredNextButton) {
            return;
        }

        this.registerButton(this.$nextBtn, function () {
            if (self.currentPageIndex === self.pagesCount) {
                self.disableButton(self.$nextBtn);
                self.registeredNextButton = false;
                return;
            }

            self.changingPage(self.currentPageIndex + 1);
        });

        this.registeredNextButton = true;
    };

    Plugin.prototype.registerLastButton = function () {
        var self = this;

        if (this.registeredLastButton) {
            return;
        }

        this.registerButton(this.$lastBtn, function () {
            if (self.currentPageIndex === self.pagesCount) {
                self.disableButton(self.$lastBtn);
                self.registeredLastButton = false;
                return;
            }
            
            self.changingPage(self.pagesCount);
        });

        this.registeredLastButton = true;
    };

    Plugin.prototype.registerButton = function ($button, callback) {
        if (!$button) {
            return;
        }

        $button.click(function () {
            callback();
        });
    };

    Plugin.prototype.disableButton = function ($button) {
        if (!$button) {
            return;
        }

        $button.unbind('click').attr('disabled', true);
    };

    Plugin.prototype.changingPage = function (pageIndex) {
        this.currentPageIndex = pageIndex;
        this.setPageIndex();
        this.register();

        if (this.options.onChangingPage) {
            this.options.onChangingPage(pageIndex);
        }
    };

    Plugin.prototype.createButton = function (text, liClass) {
        if (!text) {
            return null;
        }

        var $button = $('<li></li>');

        if (liClass) {
            $button.addClass(liClass);
        }

        var $a = $('<a href="javascript:void(0);"></a>').html(text);
        return $button.append($a);
    };

    Plugin.prototype.createPage = function () {
        var $li = $('<li class="page"></li>');
        var $div = $('<div class="show-page"></div>').html(this.getPageText());
        var $input = $('<input type="text" value="" class="hidden" />').val(this.currentPageIndex);
        return $li.append($div).append($input);
    };

    Plugin.prototype.setPageIndex = function () {
        this.$page.children('.show-page').html(this.getPageText());
        this.$page.children('[input]').val(this.currentPageIndex);
    };

    Plugin.prototype.getPageText = function () {
        var regExp = new RegExp(this.options.pageIndexPattern, 'g');
        return this.options.pageText.replace(regExp, this.currentPageIndex);
    };

    function calculatePagesCount(totalRecords, pageSize) {
        var count = parseInt(totalRecords / pageSize);

        if (totalRecords % pageSize > 0) {
            count++;
        }

        return count;
    }

    function getCustomPageIndex(customPageIndex, pagesCount) {
        return customPageIndex > pagesCount ? pagesCount : customPageIndex;
    }

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);