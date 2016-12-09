;
(function ($, window, document, undefined) {
    var pluginName = 'uploadHelper',
        version = '20160303';

    var defaults = {
        url: '',
        beforeUpload: function () { },
        uploading: function (data) { },
        uploaded: function (data) { }
    };

    function Plugin(element, options) {
        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);
        this.elementName = this.$element.attr('name');
        this.file = this.$element[0].files[0];
        this.init();
    };

    Plugin.prototype.init = function () {
        var that = this;
        var xhr = new XMLHttpRequest();
        var formData = new FormData();
        formData.append(that.elementName, this.file);

        if (this.options.beforeUpload) {
            this.options.beforeUpload();
        }

        xhr.upload.onprogress = function (data) {
            var result = {
                loaded: data.loaded,
                total: data.total
            };

            result.percentage = Math.floor(100 * result.loaded / result.total);

            if (that.options.uploading) {
                that.options.uploading(result);
            }
        };

        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                if (that.options.uploaded) {
                    that.options.uploaded(xhr.responseText);
                }
            }
        };

        xhr.open('POST', this.options.url);
        xhr.send(formData);
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$.data(this, pluginName)) {
                $.data(this, pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);