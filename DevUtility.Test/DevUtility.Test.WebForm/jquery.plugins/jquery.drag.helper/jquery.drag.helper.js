;
(function ($, window, document, undefined) {
    var pluginName = 'dragHelper',
        version = '20161205';

    var defaults = {
        dragging: function (data) { },
        dragged: function (data) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.element = this.$element[0];
        this.options = $.extend(true, {}, defaults, options);
        this.init();
    };

    Plugin.prototype.init = function () {
        this.register();
    };

    Plugin.prototype.register = function () {
        var self = this;

        document.addEventListener('dragenter', function (e) {
        }, false);

        document.addEventListener('dragleave', function (e) {
        }, false);

        this.element.addEventListener('dragleave', function (e) {
        }, false);

        this.element.addEventListener('dragenter', function (e) {
            e.stopPropagation();
            e.preventDefault();
            self.dragging(e.dataTransfer.files);
        }, false);

        this.element.addEventListener('dragover', function (e) {
            e.stopPropagation();
            e.preventDefault();
        }, false);

        this.element.addEventListener('drop', function (e) {
            e.stopPropagation();
            e.preventDefault();
            self.dragged(e.dataTransfer.files);
        }, false);
    };

    Plugin.prototype.dragging = function (files) {
        if (this.options.dragging) {
            this.options.dragging(files);
        }
    };

    Plugin.prototype.dragged = function (files) {
        if (this.options.dragged) {
            this.options.dragged(files);
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