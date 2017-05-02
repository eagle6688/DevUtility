;
(function ($, window, document, undefined) {
    var pluginName = 'popup',
        version = '20170502';

    var defaults = {
        backgroundID: 'alert-background',
        popupID: '',
        messageID: '',
        btn_OK_ID: '',
        btn_Close_ID: '',
        btn_Cancel_ID: ''
    };

    function Plugin(options) {
        this.options = $.extend({}, defaults, options);
        this._init();
    };

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype._init = function () {
        this._verify();

        var maxZIndex = getMaxZIndex();
        this._initBackground(maxZIndex + 1);
        this._initPopup(maxZIndex + 2);
    };

    Plugin.prototype._verify = function () {
        if (!this._exist('popupID')) {
            throw ('popupID can not found!');
        }

        if (!this._exist('messageID')) {
            throw ('messageID can not found!');
        }

        if (!this._exist('btn_OK_ID')) {
            throw ('btn_OK_ID can not found!');
        }

        if (!this._exist('btn_Close_ID')) {
            throw ('btn_Close_ID can not found!');
        }
    };

    Plugin.prototype._initBackground = function (zIndex) {
        this.$background = $('#' + this.options.backgroundID);

        if (this.$background.length === 0) {
            this._createBackground();
        }

        this._initBackgroundStyle();
        this._setBackgroundStyle(zIndex);
    };

    Plugin.prototype._createBackground = function () {
        this.$background = $('<div></div>').attr('id', this.options.backgroundID);
        $('body').append(this.$background);
    };

    Plugin.prototype._initBackgroundStyle = function () {
        this.$background.css({
            display: 'none',
            backgroundColor: '#ccc',
            left: 0,
            top: 0,
            '_top': 'expression(eval(document.compatMode && document.compatMode==\'CSS1Compat\') ? documentElement.scrollTop + (document.documentElement.clientHeight-this.offsetHeight)/2 : document.body.scrollTop + (document.body.clientHeight - this.clientHeight)/2);',
            filter: 'alpha(opacity=50)', /*IE*/
            opacity: '0.5', /*FF*/
            position: 'fixed !important', /*FF IE7*/
            position: 'absolute' /*IE6*/
        });
    };

    Plugin.prototype._setBackgroundStyle = function (zIndex) {
        this.$background.css({
            zIndex: zIndex,
            width: getScrollWidth(),
            height: getScrollHeight()
        });
    };

    Plugin.prototype._initPopup = function (zIndex) {
        this.$popup = $('#' + this.options.popupID);
        this.$message = $('#' + this.options.messageID);
        this.$btnOK = $('#' + this.options.btn_OK_ID);
        this.$btnClose = $('#' + this.options.btn_Close_ID);
        this.$btnCancel = $('#' + this.options.btn_Cancel_ID);
        this._initPopupStyle();
        this._setPopupStyle(zIndex);
    };

    Plugin.prototype._initPopupStyle = function () {
        this.$popup.css({
            'left': '50%',
            'top': '50%',
            'position': 'absolute',
            'display': 'none'
        });
    };

    Plugin.prototype._setPopupStyle = function (zIndex) {
        var width = this.$popup.width();
        var height = this.$popup.height();
        var marginLeft = -(width / 2);
        var marginTop = -(height / 2);

        this.$popup.css({
            'margin-left': marginLeft,
            'margin-top': marginTop,
            'zIndex': zIndex
        });
    };

    Plugin.prototype._exist = function (name) {
        if (this.options[name] && $('#' + this.options[name]).length > 0) {
            return true;
        }

        return false;
    };

    Plugin.prototype._setMessage = function (message) {
        this.$message.html(message);
    };

    Plugin.prototype._register = function (okCallback, closeCallback, cancelCallback) {
        var self = this;

        this.$btnOK.unbind('click').click(function (e) {
            e.stopPropagation();
            self._hide();

            if (okCallback) {
                okCallback();
            }
        });

        this.$btnClose.unbind('click').click(function (e) {
            e.stopPropagation();
            self._hide();

            if (closeCallback) {
                closeCallback();
            }
        });

        if (this.$btnCancel.length > 0) {
            this.$btnCancel.unbind('click').click(function (e) {
                e.stopPropagation();
                self._hide();

                if (cancelCallback) {
                    cancelCallback();
                }
            });
        }
    };

    Plugin.prototype._show = function () {
        var maxZIndex = getMaxZIndex();
        this._setBackgroundStyle(maxZIndex + 1);
        this._setPopupStyle(maxZIndex + 2);
        this.$background.show();
        this.$popup.css('display', 'block');
    };

    Plugin.prototype._hide = function () {
        this.$popup.css('display', 'none');
        this.$background.hide();
    };

    function getScrollWidth() {
        return Math.max(document.body.scrollWidth, document.documentElement.scrollWidth);
    };

    function getScrollHeight() {
        return Math.max(document.body.scrollHeight, document.documentElement.scrollHeight);
    };

    function getMaxZIndex() {
        var value = 0;

        $("*").each(function (index, element) {
            var zIndex = ~~$(element).css('z-index');

            if (value < zIndex) {
                value = zIndex;
            }
        });

        return value;
    };

    Plugin.prototype.alert = function (message, okCallback, closeCallback) {
        this._register(okCallback, closeCallback);
        this._setMessage(message);
        this._show();
    };

    Plugin.prototype.comfirm = function (message, okCallback, closeCallback, cancelCallback) {
        this._register(okCallback, closeCallback, cancelCallback);
        this._setMessage(message);
        this._show();
    };

    $[pluginName] = function (options) {
        return new Plugin(options);
    };
})(jQuery, window, document);