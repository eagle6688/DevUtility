(function ($, window, document, undefined) {
    var pluginName = 'koTableHelper',
        version = 'v4.0.20170804';

    var defaults = {
        url: '',
        requestType: 'GET',
        requestData: null,
        viewModel: null,
        selectAllBtn: '#cb-selectAll',
        selectItemsSelector: 'tbody input[type="checkbox"]',
        pageSize: 10,
        autoLoad: true,
        noDataDom: '', //Dom displays when there is no datum loaded.
        loadingDom: '', //Dom displays when data are loading.
        beforeLoadData: function (data) { },
        afterLoadData: function (data) { }
    };

    function Plugin(element, options) {
        this.element = element;
        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);
        this._init();
    }

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._init = function () {

    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);