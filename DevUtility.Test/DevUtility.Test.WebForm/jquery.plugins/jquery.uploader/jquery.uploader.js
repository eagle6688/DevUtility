;
(function ($, window, document, undefined) {
    var pluginName = 'uploader',
        version = '20170219';

    var defaults = {
        url: '',
        file: null,
        formData: null,
        callbackData: null,
        uploading: function (data) { },
        uploaded: function (data) { },
        failed: function (data) { }
    };

    var resultTypes = {
        abort: 'abort',
        error: 'error',
        timeout: 'timeout',
        server: 'server'
    };

    function Plugin(options) {
        this.options = $.extend(true, {}, defaults, options);
        this.init();
    }

    Plugin.prototype.init = function () {
        var self = this;
        this.xhr = new XMLHttpRequest();

        this.xhr.upload.onprogress = function (data) {
            self._onprogress(data);
        };

        this.xhr.onloadend = function () {
            self._onloadend();
        };

        this.xhr.onabort = function (e) {
            var result = self._createResult(resultTypes.abort, e);
            self._failed(result);
        };

        this.xhr.onerror = function (e) {
            var result = self._createResult(resultTypes.error, e);
            self._failed(result);
        };

        this.xhr.ontimeout = function (e) {
            var result = self._createResult(resultTypes.timeout, e);
            self._failed(result);
        };
    };

    Plugin.prototype.upload = function () {
        var formData = this._createFormData();
        this.xhr.open('POST', this.options.url);
        this.xhr.send(formData);
    };

    Plugin.prototype._createFormData = function () {
        var formData = this.options.formData;

        if (!formData) {
            formData = new FormData();
        }

        formData.set('file', this.options.file);
        return formData;
    };

    Plugin.prototype._onprogress = function (data) {
        var state = {
            loaded: data.loaded,
            total: data.total,
            percentage: Math.floor(100 * data.loaded / data.total)
        };

        if (this.options.uploading) {
            this.options.uploading(state);
        }
    };

    Plugin.prototype._onloadend = function () {
        if ((this.xhr.status >= 200 && this.xhr.status < 300) || this.xhr.status === 304) {
            this._uploaded(this._createResult(resultTypes.server, this.xhr.responseText));
        }
        else {
            this._failed(this._createResult(resultTypes.error, this.xhr.responseText));
        }
    };

    Plugin.prototype._uploaded = function (data) {
        if (this.options.uploaded) {
            this.options.uploaded(data, this.options.callbackData);
        }
    };

    Plugin.prototype._failed = function (data) {
        if (this.options.failed) {
            this.options.failed(data, this.options.callbackData);
        }
    };

    Plugin.prototype._createResult = function (type, response) {
        var result = {
            type: type
        };

        if (resultTypes.server === type) {
            result.response = $.parseJSON(response);
        }
        else {
            result.response = response;
        }

        return result;
    };

    $[pluginName] = function (options) {
        return new Plugin(options);
    };
})(jQuery, window, document);