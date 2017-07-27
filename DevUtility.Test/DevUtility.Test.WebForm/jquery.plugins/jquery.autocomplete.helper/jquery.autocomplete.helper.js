;
(function ($, window, document, undefined) {
    var pluginName = 'autocompleteHelper',
        version = '20170727';

    var defaults = {
        data: [],
        appendTo: null,
        select: function (data, event, ui) { },
        search: function (data) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);
        this._init();
    };

    Plugin.prototype._init = function () {
        this.data = {
            isSelected: false,
            keyword: ''
        };

        this._register();
    };

    Plugin.prototype._register = function () {
        var self = this;

        this.$element.autocomplete({
            source: this.options.data,
            appendTo: this.options.appendTo,
            select: function (event, ui) {
                self._select(event, ui);
            }
        });
    };

    Plugin.prototype._select = function (event, ui) {
        this.data = {
            isSelected: true,
            keyword: ui.item.value
        };

        if (this.options.select) {
            this.options.select(this.data, event, ui);
        }

        this._search(this.data);
    };

    Plugin.prototype._search = function (data) {
        if (this.options.search) {
            this.options.search(data);
        }
    };

    //export functions

    Plugin.prototype.getData = function () {
        var value = $.trim(this.$element.val());

        if (this.data.keyword != value) {
            this.data.keyword = value;
            this.data.isSelected = false;
        }

        return this.data;
    };

    Plugin.prototype.search = function () {
        var data = this.getData();
        this._search(data);
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);