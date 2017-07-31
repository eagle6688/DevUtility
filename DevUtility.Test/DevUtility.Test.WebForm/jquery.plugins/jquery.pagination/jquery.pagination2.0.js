(function ($, window, document, undefined) {
    var pluginName = 'pagination',
        version = 'v2.0.20170731';

    var defaults = {
        totalRecords: 0,
        pageSize: 10,
        pageIndex: 1,
        visiblePages: 7, //Visible pages count.
        changingType: 'ajax', //Two action type when changing page: 'jump', 'ajax'.
        pageTagName: 'data-page', //Tag name of page number.
        liClassName: 'page', //Style for every page's 'li'.
        firstButtonName: 'First', //Button's text of First.
        firstButtonClass: 'first', //Button's style of First.
        preButtonName: 'Previous', //Button's text of Previous.
        preButtonClass: 'prev', //Button's style of Previous.
        nextButtonName: 'Next', //Button's text of Next.
        nextButtonClass: 'next', //Button's style of Next.
        lastButtonName: 'Last', //Button's text of Last.
        lastButtonClass: 'last', //Button's style of Last.
        disabledButtonClass: 'disabled', //Button's style of disabled.
        currentButtonClass: 'active', //Button's style of current clicked.
        ulClass: 'pagination pagination-sm', //Class of ul
        positionID: '',
        onPageClick: null, //Event that on click.
        afterPageClick: null, //Event that after click.
        onReload: function (recordsCount, pageIndex, pageSize) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, defaults, options);
        this.init();
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype.init = function () {
        if (!this.verifyParameter()) {
            console.error('Parameter error!');
            return;
        }

        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);

        if (this.pagesCount === 0) {
            this.$element.hide();
            return;
        }

        this.$element.show();
        this.middlePage = getMiddlePage(this.options.visiblePages);
        this.currentPage = getDefaultPage(this.pagesCount, ~~this.options.pageIndex);
        this.firstVisiblePage = getFirstVisiblePage(this.currentPage, this.options.visiblePages, this.middlePage, this.pagesCount);
        this.lastVisiblePage = getLastVisiblePage(this.currentPage, this.options.visiblePages, this.middlePage, this.pagesCount);
        this.createPagination();
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

        if (this.options.onReload) {
            this.options.onReload(recordsCount, pageIndex, pageSize);
        }
    };

    Plugin.prototype.verifyParameter = function () {
        var options = this.options;

        if (isNaN(options.totalRecords) || options.totalRecords < 0) {
            return false;
        }

        if (isNaN(options.pageSize) || options.pageSize < 1) {
            return false;
        }

        if (isNaN(options.visiblePages) || options.visiblePages < 1) {
            return false;
        }

        if (isNaN(options.pageIndex) || options.pageIndex < 1) {
            return false;
        }

        return true;
    };

    Plugin.prototype.verifyInitPage = function () {
        if (this.options.pageIndex > this.pagesCount) {
            return false;
        }

        return true;
    };

    Plugin.prototype.createPagination = function () {
        this.$element.children().remove();
        this.$element.append(this.generatePagination());
    };

    Plugin.prototype.generatePagination = function () {
        var canClick = true;
        var className = '';
        var currentPage = this.currentPage;
        var firstVisiblePage = this.firstVisiblePage;
        var lastVisiblePage = this.lastVisiblePage;
        var $listContainer = $('<ul></ul>');

        if (this.options.ulClass) {
            $listContainer.addClass(this.options.ulClass);
        }

        if (firstVisiblePage === currentPage) {
            $listContainer.append(this.getFirstButton(false));
            $listContainer.append(this.getPreButton(false));
        }
        else {
            $listContainer.append(this.getFirstButton(true));
            $listContainer.append(this.getPreButton(true));
        }

        for (var i = firstVisiblePage; i < lastVisiblePage + 1; i++) {
            className = this.options.liClassName;
            canClick = true;

            if (i === this.currentPage) {
                canClick = false;
                className = this.options.liClassName + ' ' + this.options.currentButtonClass;
            }

            $listContainer.append(this.generateLink(i, className, i, canClick));
        }

        if (lastVisiblePage === currentPage) {
            $listContainer.append(this.getNextButton(false));
            $listContainer.append(this.getLastButton(false));
        }
        else {
            $listContainer.append(this.getNextButton(true));
            $listContainer.append(this.getLastButton(true));
        }

        return $listContainer;
    };

    Plugin.prototype.getFirstButton = function (available) {
        if (!this.options.firstButtonClass && !this.options.firstButtonName) {
            return null;
        }

        var className = this.options.firstButtonClass;

        if (!available) {
            className += ' ' + this.options.disabledButtonClass;
        }

        return this.generateLink(this.options.firstButtonName, className, -4, available);
    };

    Plugin.prototype.getPreButton = function (available) {
        if (!this.options.preButtonClass && !this.options.preButtonName) {
            return null;
        }

        var className = this.options.preButtonClass;

        if (!available) {
            className += ' ' + this.options.disabledButtonClass;
        }

        return this.generateLink(this.options.preButtonName, className, -3, available);
    };

    Plugin.prototype.getNextButton = function (available) {
        if (!this.options.nextButtonClass && !this.options.nextButtonName) {
            return null;
        }

        var className = this.options.nextButtonClass;

        if (!available) {
            className += ' ' + this.options.disabledButtonClass;
        }

        return this.generateLink(this.options.nextButtonName, className, -2, available);
    };

    Plugin.prototype.getLastButton = function (available) {
        if (!this.options.lastButtonClass && !this.options.lastButtonName) {
            return null;
        }

        var className = this.options.lastButtonName;

        if (!available) {
            className += ' ' + this.options.disabledButtonClass;
        }

        return this.generateLink(this.options.lastButtonName, className, -1, available);
    };

    Plugin.prototype.generateLink = function (text, className, pageNum, canClick) {
        var that = this;
        var pageTagName = that.options.pageTagName;
        var onPageClick = that.options.onPageClick;
        var afterPageClick = that.options.afterPageClick;
        var link = $('<li><a href="javascript:void(0);">' + text + '</a></li>');
        link.addClass(className);
        link.attr(pageTagName, pageNum);

        if (canClick) {
            link.bind('click', function () {
                var pageIndex = getCurrentPage(parseInt($(this).attr(pageTagName)), that.currentPage, that.pagesCount);

                if (onPageClick) {
                    onPageClick(pageIndex);
                }

                that.changingPage(pageIndex);

                if (afterPageClick) {
                    afterPageClick(pageIndex);
                }

                if (that.options.positionID) {
                    document.getElementById(that.options.positionID).scrollIntoView();
                }
                else {
                    document.documentElement.scrollTop = document.body.scrollTop = 0;
                }
            });
        }

        return link;
    };

    Plugin.prototype.changingPage = function (pageIndex) {
        this.currentPage = pageIndex;
        this.firstVisiblePage = getFirstVisiblePage(this.currentPage, this.options.visiblePages, this.middlePage, this.pagesCount);
        this.lastVisiblePage = getLastVisiblePage(this.currentPage, this.options.visiblePages, this.middlePage, this.pagesCount);
        this.createPagination();
    };

    function calculatePagesCount(totalRecords, pageSize) {
        var count = 0;

        if (!isNaN(totalRecords) && !isNaN(pageSize) && pageSize > 0) {
            count = parseInt(totalRecords / pageSize);

            if (totalRecords % pageSize > 0) {
                count++;
            }
        }

        count = count === 0 ? 1 : count;
        return count;
    }

    function getMiddlePage(visiblePages) {
        var middlePage = parseInt(visiblePages / 2);
        middlePage = visiblePages % 2 > 0 ? middlePage + 1 : middlePage;
        return middlePage;
    }

    function getDefaultPage(pagesCount, customerDefaultPage) {
        if (customerDefaultPage > pagesCount)
            return pagesCount;

        return customerDefaultPage;
    }

    function getFirstVisiblePage(currentPage, visiblePages, middlePage, pagesCount) {
        if (pagesCount <= visiblePages) {
            return 1;
        }

        var pageIndex = currentPage - middlePage + 1;

        if (currentPage > pagesCount - middlePage) {
            return pagesCount - visiblePages + 1;
        }

        return pageIndex < 1 ? 1 : pageIndex;
    }

    function getLastVisiblePage(currentPage, visiblePages, middlePage, pagesCount) {
        if (pagesCount <= visiblePages) {
            return pagesCount;
        }

        var pageIndex = currentPage + middlePage - 1;

        if (pageIndex < visiblePages) {
            return visiblePages;
        }

        return pageIndex > pagesCount ? pagesCount : pageIndex;
    }

    function getCurrentPage(pageIndex, prePage, pagesCount) {
        switch (pageIndex) {
            case -4:
                return 1;

            case -3:
                {
                    if (prePage > 1) {
                        return prePage - 1;
                    }

                    return 1;
                }

            case -2:
                {
                    if (prePage < pagesCount) {
                        return prePage + 1;
                    }

                    return pagesCount;
                }

            case -1:
                return pagesCount;

            default:
                return pageIndex;
        }
    }

    $[pluginName] = {
        getDefaults: function () {
            return defaults;
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