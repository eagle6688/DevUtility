(function ($, window, document, undefined) {
    var pluginName = 'paginationmobile',
        version = '20170710';

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
        paginationClass: '',
        canInputIndex: true,
        onChangingPage: function (pageIndex) { },


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
        isInputIndex: true
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
        this.pagesCount = calculatePagesCount(this.options.totalRecords, this.options.pageSize);

        if (this.pagesCount > 0) {
            this.currentPageIndex = getCustomPageIndex(this.options.pageIndex, this.pagesCount);
            this.initPagination();
            this.setPagination();
        }
    };

    Plugin.prototype.initPagination = function () {
        this.$pagination = $('<ul></ul>');

        if (this.options.paginationClass) {
            this.$pagination.addClass(this.options.paginationClass);
        }

        this.$firstBtn = createButton(this.options.firstBtnText, this.options.firstBtnClass, null, 'javascript:void(0);');
        this.$prevBtn = createButton(this.options.prevBtnText, this.options.prevBtnClass, null, 'javascript:void(0);');
        this.$nextBtn = createButton(this.options.nextBtnText, this.options.nextBtnClass, null, 'javascript:void(0);');
        this.$lastBtn = createButton(this.options.lastBtnText, this.options.lastBtnClass, null, 'javascript:void(0);');
        this.$pagination.append(this.$firstBtn, this.$prevBtn, this.$nextBtn, this.$lastBtn);
    };

    Plugin.prototype.setPagination = function () {
        this.$pagination.empty();
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
        if (this.pagesCount == 1 || this.currentPageIndex == 1 || !this.listFirstBtnVisiable) {
            className += ' hidden';
        }
        return this.generateLi(this.options.listFirstBtnText, className, 1);
    };

    Plugin.prototype.getListLastBtn = function () {
        var className = 'last';
        if (this.currentPageIndex == this.pagesCount || !this.listFirstBtnVisiable) {
            className += ' hidden';
        }
        return this.generateLi(this.options.listLastBtnText, className, this.pagesCount);
    };

    Plugin.prototype.getListPrevBtn = function () {
        var className = 'prev';

        if (this.currentPageIndex == 1) {
            className += ' disabled';
        }
        return this.generateLi(this.options.listPrevBtnText, className, this.currentPageIndex - 1);
    };

    Plugin.prototype.getListNextBtn = function () {
        var className = 'next';
        if (this.currentPageIndex == this.pagesCount) {
            className += ' disabled';
        }
        return this.generateLi(this.options.listNextBtnText, className, this.currentPageIndex);
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
        this.$element.find(".page>input").val(this.currentPageIndex);
        this.$element.find(".page-index").text(this.currentPageIndex);

        if (this.currentPageIndex === 1) {
            this.$element.find(".prev").addClass("disabled");
            this.$element.find(".next").removeClass("disabled");
            this.$element.find(".first").addClass("hidden").siblings(".last").removeClass("hidden");
        }

        if (this.currentPageIndex === this.pagesCount) {
            this.$element.find(".next").addClass("disabled");
            this.$element.find(".prev").removeClass("disabled");
            this.$element.find(".last").addClass("hidden").siblings(".first").removeClass("hidden");
        }
    }

    var createButton = function (text, liClass, aClass, href) {
        if (!text) {
            return null;
        }

        var $button = $('<li></li>');

        if (liClass) {
            $button.addClass(liClass);
        }

        var $a = $('<a></a>').text(text);

        if (aClass) {
            $a.addClass(aClass);
        }

        if (href) {
            $a.attr('href', href);
        }

        return $button.append($a);
    };

    var createPage = function (text, pattern, pageIndex, liClass, divClass) {
        if (!pageIndex) {
            return null;
        }

        var $li = $('<li></li>');

        if (liClass) {
            $li.addClass(liClass);
        }

        var regExp = new RegExp(pattern, 'g');
        var value = text.replace(regExp, pageIndex);
        var $div = $('<div></div>').html(value);

        if (divClass) {
            $div.addClass(divClass);
        }

        var $input = $('<input type="text" value="" class="hidden" />').val(pageIndex);
        return $li.append($div).append($input);
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
            var plugin = new Plugin(this, options)
        })
    };
})(jQuery, window, document);