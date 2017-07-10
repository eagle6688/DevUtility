﻿(function ($, window, document, undefined) {
    var pluginName = 'paginationmobile',
        version = '20170710';

    var defaults = {
        totalRecords: 0,
        pageSize: 10,
        currentPageIndex: 1,
        nextButtonShow: true,
        pageString: 'Page ',
        pageDataName: 'data-page-index',
        listFirstBtnText: '&lt;&lt;',
        listFirstBtnVisiable: false,
        listLastBtnText: '&gt;&gt;',
        listLastBtnVisiable: false,
        listPrevBtnText: '&lt;',
        listNextBtnText: '&gt',
        isInputIndex: true,
        onChangingPage: null
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.options = $.extend({}, defaults, options);
        if (this.verifyParameter()) {
            this.init();
        } else {
            console.error("Parameter error!")
        }
    }
    Plugin.prototype.constructor = Plugin;
    Plugin.prototype.verifyParameter = function () {
        var options = this.options;
        if (isNaN(options.totalRecords) || options.pageSize < 1) {
            return false;
        }
        if (isNaN(options.pageSize) || options.pageSize < 1) {
            return false;
        }
        if (isNaN(options.currentPageIndex) || options.currentPageIndex < 1) {
            return false;
        }
        return true;
    };
    Plugin.prototype.init = function () {
        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);
        if (this.pagesCount > 0) {
            this.currentPage = getDefaultPage(this.pagesCount, this.options.currentPageIndex);
            this.createPagination();
        }
    };
    Plugin.prototype.createPagination = function () {
        this.$element.empty();
        this.$element.append(this.generatePagination());
    };
    Plugin.prototype.generatePagination = function () {
        var currentPage = this.currentPage,
            className = "",
            $pagerContainer = $('<div class="pager"></div>');

        if (this.options.nextButtonShow) {
            $pagerContainer.append(this.getNextButton(true));
        } else {
            $pagerContainer.append(this.getPagerList());
        }
        return $pagerContainer;
    };
    Plugin.prototype.getNextButton = function (available) {
        var _this = this,
            className = 'next',
            $nextBtn = $('<button><a href="javascript:;">Next</a><i>></i></button>');

        if (this.pagesCount == 1) {
            className += ' disabled';
        }
        $nextBtn.addClass(className);
        $nextBtn.attr(_this.options.pageDataName, 1);
        $nextBtn.bind("click", function () {
            _this.options.nextButtonShow = false;
            _this.currentPage++;
            _this.createPagination();
        });
        return $nextBtn;
    };

    Plugin.prototype.getPagerList = function () {
        var $ulList = $('<ul class="ul-pager"></ul>');
        $ulList.append(this.getListFirstBtn());
        $ulList.append(this.getListPrevBtn());
        $ulList.append(this.getPageInput());
        $ulList.append(this.getListNextBtn());
        $ulList.append(this.getListLastBtn());
        return $ulList;
    };
    Plugin.prototype.getListFirstBtn = function () {
        var className = 'first';
        if (this.pagesCount == 1 || this.currentPage == 1 || !this.listFirstBtnVisiable) {
            className += ' hidden';
        }
        return this.generateLi(this.options.listFirstBtnText, className, 1);
    };

    Plugin.prototype.getListLastBtn = function () {
        var className = 'last';
        if (this.currentPage == this.pagesCount || !this.listFirstBtnVisiable) {
            className += ' hidden';
        }
        return this.generateLi(this.options.listLastBtnText, className, this.pagesCount);
    };

    Plugin.prototype.getListPrevBtn = function () {
        var className = 'prev';

        if (this.currentPage == 1) {
            className += ' disabled';
        }
        return this.generateLi(this.options.listPrevBtnText, className, this.currentPage - 1);
    };

    Plugin.prototype.getListNextBtn = function () {
        var className = 'next';
        if (this.currentPage == this.pagesCount) {
            className += ' disabled';
        }
        return this.generateLi(this.options.listNextBtnText, className, this.currentPage);
    };

    Plugin.prototype.generateLi = function (text, className, pageIndex) {
        var _this = this,
           pageDataName = _this.options.pageDataName,
           onChangingPage = _this.options.onChangingPage,
           $li = $('<li><a href="javascript:void(0);">' + text + "</a></li>");
        $li.addClass(className);
        $li.attr(pageDataName, pageIndex);

        if (className.indexOf('next') != -1) {
            $li.bind("click", function () {
                _this.currentPage = _this.currentPage === _this.pagesCount ? _this.pagesCount : _this.currentPage + 1;
                $(this).siblings(".prev").removeClass("disabled");
                _this.setCurrentStatus();
            });
        }

        if (className.indexOf('prev') != -1) {
            $li.bind("click", function () {
                _this.currentPage = _this.currentPage === 1 ? 1 : _this.currentPage - 1;
                $(this).siblings(".next").removeClass("disabled");
                _this.setCurrentStatus();
            });
        }

        if (className.indexOf('first') != -1) {
            $li.bind("click", function () {
                _this.currentPage = 1;
                $(this).addClass("hidden").siblings(".last").removeClass("hidden");
                _this.setCurrentStatus();
            });
        }

        if (className.indexOf('last') != -1) {
            $li.bind("click", function () {
                _this.currentPage = _this.pagesCount;
                $(this).addClass("hidden").siblings(".first").removeClass("hidden");
                _this.setCurrentStatus();
            });
        }

        $li.bind("click", function () {
            if (onChangingPage) {
                onChangingPage(_this.currentPage);
            }
        });
        return $li;
    };

    Plugin.prototype.getPageInput = function () {
        var _this = this,
            onChangingPage = _this.options.onChangingPage,
            $li = $('<li class="page"></li>'),
            $pageString = $('<div class="show-page"></div>'),
            $label = $('<label class="page-index">1</label>'),
            $input = $('<input type="text" value="1">');
        $pageString.text(_this.options.pageString);
        $label.text(_this.currentPage);
        $pageString.append($label);
        $input.val(_this.currentPage);
        $li.append($pageString);
        $li.attr(_this.options.pageDataName, _this.currentPage);

        if (_this.options.isInputIndex) {
            $pageString.bind("click", function () {
                $(this).addClass("hidden");
                $li.append($input);
                $input.removeClass("hidden").focus();
            });
            $input.bind("blur", function () {
                var num = parseInt($(this).val().trim());
                if (!isNaN(num)) {
                    if (num > _this.pagesCount) {
                        num = _this.pagesCount;
                    }
                    if (num < 1) {
                        num = 1;
                    }
                    _this.currentPage = num;
                }
                if (onChangingPage) {
                    onChangingPage(_this.currentPage);
                }
                $li.attr(_this.options.pageDataName, _this.currentPage);
                _this.setCurrentStatus();
                $(this).addClass("hidden").siblings(".show-page").removeClass("hidden");
            });
            $input.keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode === 13) {
                    $(this).trigger("blur");
                }
            });
        }
        return $li;
    };

    Plugin.prototype.setCurrentStatus = function () {
        this.$element.find(".page>input").val(this.currentPage);
        this.$element.find(".page-index").text(this.currentPage);
        if (this.currentPage === 1) {
            this.$element.find(".prev").addClass("disabled");
            this.$element.find(".next").removeClass("disabled");
            this.$element.find(".first").addClass("hidden").siblings(".last").removeClass("hidden");
        }
        if (this.currentPage === this.pagesCount) {
            this.$element.find(".next").addClass("disabled");
            this.$element.find(".prev").removeClass("disabled");
            this.$element.find(".last").addClass("hidden").siblings(".first").removeClass("hidden");
        }
    }

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

    function getDefaultPage(pagesCount, customerDefaultPage) {
        return customerDefaultPage > pagesCount ? pagesCount : customerDefaultPage;
    }

    $[pluginName] = {
        getDefaults: function () {
            return defaults
        }
    };
    $.fn[pluginName] = function (options) {
        return this.each(function () {
            var plugin = new Plugin(this, options)
        })
    };

})(jQuery, window, document);