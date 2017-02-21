;
(function ($, window, document, undefined) {
    var pluginName = 'slicingUploader',
        version = '20170221';

    var defaults = {
        file: null,
        url: '',
        uploadThreadsCount: 1,
        sliceSize: 1 * 1024 * 1024,
        needMD5Checksum: true,
        reTryTimes: 6,
        formData: null,
        formNames: {
            fileName: 'fileName',
            fileSize: 'fileSize',
            sliceIndex: 'sliceIndex',
            sliceCount: 'sliceCount',
            sliceChecksum: 'sliceChecksum',
            uploadTime: 'uploadTime'
        },
        beforeUpload: function (data) { },
        uploading: function (data) { },
        uploaded: function (data) { },
        failed: function (data) { }
    };

    function Plugin(options) {
        this.options = $.extend(true, {}, defaults, options);
        this.init();
    }

    Plugin.prototype.init = function () {
        if (!this._checkBrowser()) {
            return;
        }

        this._initModel();
        this._initQueue();
    };

    Plugin.prototype._checkBrowser = function () {
        var message = 'Your browser does not support this function, we suggest you use the latest version of Firefox or Chrome!';

        if (!window.FormData) {
            alert(message);
            return false;
        }

        var formData = new FormData();

        if (!formData.set) {
            alert(message);
            return false;
        }

        if (this.options.needMD5Checksum && !window.FileReader) {
            alert(message);
            return false;
        }

        return true;
    };

    Plugin.prototype._initModel = function () {
        // Can not put these two variables in model.
        this.loaded = 0;
        this.percentage = 0;

        if (this.options.sliceSize === 0) {
            this.options.sliceSize = this.options.file.size;
        }

        this.model = {
            uploadTime: new Date(),
            name: this.options.file.name,
            size: this.options.file.size,
            sliceCount: Math.ceil(this.options.file.size / this.options.sliceSize)
        };
    };

    Plugin.prototype._initQueue = function () {
        this.slicesQueue = [];
        this.failedSlicesQueue = [];

        for (var i = 0; i < this.model.sliceCount; i++) {
            var start = i * this.options.sliceSize,
                end = Math.min(this.options.file.size, start + this.options.sliceSize);

            var slice = this._createSlice(i, start, end);
            this.slicesQueue.push(slice);
        }
    };

    Plugin.prototype._createSlice = function (index, start, end) {
        return {
            result: null,
            index: index,
            size: end - start,
            start: start,
            end: end,
            times: 1
        };
    };

    Plugin.prototype.upload = function () {
        if (this.options.beforeUpload) {
            this.options.beforeUpload(this.model);
        }

        for (var i = 0; i < Math.min(this.model.sliceCount, this.options.uploadThreadsCount) ; i++) {
            this._uploadNext();
        }
    };

    Plugin.prototype._uploadNext = function () {
        if (this.slicesQueue.length === 0) {
            return;
        }

        var self = this,
            sliceModel = this._createNextSliceModel();

        if (this.options.needMD5Checksum) {
            checksumMD5(sliceModel.file, function (md5) {
                if (md5) {
                    sliceModel.formData.set(self.options.formNames.sliceChecksum, md5);
                }

                self._executeUpload(sliceModel);
            });
        }
        else {
            this._executeUpload(sliceModel);
        }
    };

    Plugin.prototype._createNextSliceModel = function () {
        var model = {
            slice: this.slicesQueue.shift()
        };

        model.file = this.options.file.slice(model.slice.start, model.slice.end);
        model.formData = this._createFormData(model.slice);
        return model;
    };

    Plugin.prototype._createFormData = function (slice) {
        var formData = this.options.formData;

        if (!formData) {
            formData = new FormData();
        }

        formData.set(this.options.formNames.uploadTime, getDateStr(this.model.uploadTime));
        formData.set(this.options.formNames.fileName, this.model.name);
        formData.set(this.options.formNames.fileSize, this.model.size);
        formData.set(this.options.formNames.sliceIndex, slice.index);
        formData.set(this.options.formNames.sliceCount, this.model.sliceCount);
        return formData;
    };

    Plugin.prototype._executeUpload = function (sliceModel) {
        var uploader = this._createUploader(sliceModel);
        sliceModel = null;
        uploader.upload();
    };

    Plugin.prototype._createUploader = function (sliceModel) {
        var self = this;

        return $.uploader({
            url: this.options.url,
            file: sliceModel.file,
            formData: sliceModel.formData,
            callbackData: sliceModel.slice,
            uploading: function (data) { },
            uploaded: function (data, slice) {
                self._uploadedEvent(data, slice);
            },
            failed: function (data, slice) {
                self._sliceUploadedFailed(data, slice);
            }
        });
    };

    Plugin.prototype._uploadedEvent = function (data, slice) {
        this.model.currentResult = data;
        this.model.currentSlice = slice;

        if (data && data.response && data.response.Data && data.response.Data.NeedReUpload) {
            if (slice.times <= this.options.reTryTimes) {
                slice.times += 1;
                this.slicesQueue.push(slice);
                this._uploadNext();
            }
            else {
                this._sliceUploadedFailed(data, slice);
            }

            return;
        }

        this._fileUploading(data, slice);
        this._sliceUploaded(data, slice);
    };

    Plugin.prototype._fileUploading = function (data, slice) {
        this.model.loaded = this.loaded = this.loaded + slice.size;
        this.model.percentage = this.percentage = Math.floor(100 * this.loaded / this.model.size);

        if (this.options.uploading) {
            this.options.uploading(this.model);
        }
    };

    Plugin.prototype._sliceUploaded = function (data, slice) {
        if (this.percentage === 100) {
            if (this.options.uploaded) {
                this.options.uploaded(this.model);
            }

            return;
        }

        this._uploadNext();
    };

    Plugin.prototype._sliceUploadedFailed = function (data, slice) {
        this.model.currentResult = data;
        this.model.currentSlice = slice;
        this.failedSlicesQueue.push(slice);

        if (this.options.failed) {
            this.options.failed(this.model);
        }
    };

    Plugin.prototype.reUploadFailedSlices = function () {
        for (var i = 0; i < this.failedSlicesQueue.length; i++) {
            this.slicesQueue.push(this.failedSlicesQueue[i]);
        }

        this.failedSlicesQueue = [];
        this._uploadNext();
    };

    var checksumMD5 = function (file, callback) {
        var fileReader = new FileReader();

        fileReader.onloadend = function () {
            var latin = CryptoJS.enc.Latin1.parse(this.result);
            var value = CryptoJS.MD5(latin);
            callback(value.toString());
        }

        fileReader.readAsBinaryString(file);
    };

    var getDateStr = function (time) {
        var year = time.getFullYear();
        var month = time.getMonth() + 1;
        var day = time.getDate();
        return year + '-' + month + '-' + day;
    };

    $[pluginName] = function (options) {
        var plugin = new Plugin(options);

        return {
            upload: function () {
                plugin.upload();
            },
            reUpload: function () {
                plugin.reUploadFailedSlices();
            }
        };
    };
})(jQuery, window, document);