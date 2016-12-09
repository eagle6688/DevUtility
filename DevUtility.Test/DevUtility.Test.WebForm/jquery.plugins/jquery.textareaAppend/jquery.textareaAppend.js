;
(function ($, window, document, undefined) {
    var pluginName = 'textareaAppend',
        version = '20160214';

    function Plugin(element) {
        this.element = element;
        this.$element = $(element);
    };

    Plugin.prototype.display = function (message) {
        var text = this.$element.val();

        if (text) {
            text += '\n';
        }

        text += message;
        this.$element.val(text);
        text = null;
        var scrollHeight = this.$element[0].scrollHeight;
        this.$element.scrollTop(scrollHeight);
    };

    $.fn[pluginName] = function (message) {
        return this.each(function () {
            var plugin = $.data(this, pluginName);

            if (!plugin) {
                plugin = new Plugin(this);
                $.data(this, pluginName, plugin);
            }

            plugin.display(message);
        });
    };
})(jQuery, window, document);