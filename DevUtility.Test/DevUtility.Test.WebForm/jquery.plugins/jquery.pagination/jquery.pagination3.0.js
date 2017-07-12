;
(function ($, window, document, undefined) {
    var pluginName = 'pagination',
        version = '20170712';

    var defaults = {
        totalRecords: 0,
        pageIndex: 1,
        pageSize: 10,
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
    };

    Plugin.prototype.constructor = Plugin;

    

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);