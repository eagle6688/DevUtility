;
var webSocketHelper = (function () {
    function Main(options) {
        var defaults = {
            ip: '',
            port: 0,
            onopen: function () { },
            onmessage: function (event) { },
            onclose: function () { },
            onerror: function () { }
        };

        this.options = $.extend(true, {}, defaults, options);;
        this.address = 'ws://' + this.options.ip + ':' + this.options.port + '/';
        this.init();
    };

    Main.prototype.init = function () {
        this.link();
        this.register();
    };

    Main.prototype.link = function () {
        var wsImpl = window.WebSocket || window.MozWebSocket;

        if (!wsImpl) {
            console.error('Your browser don\'t support websocket.');
            return;
        }

        this.WebSocket = new wsImpl(this.address);
    };

    Main.prototype.register = function () {
        var that = this;

        if (this.options.onopen) {
            this.WebSocket.onopen = function () {
                that.options.onopen();
            };
        }

        if (this.options.onmessage) {
            this.WebSocket.onmessage = function (event) {
                that.options.onmessage(event);
            };
        }

        if (this.options.onclose) {
            this.WebSocket.onclose = function () {
                that.options.onclose();
            };
        }

        this.WebSocket.onerror = function (event) {
            console.error('websocket error.');

            if (that.options.onerror) {
                that.options.onerror();
                that.WebSocket.close();
            }
        };
    };

    Main.prototype.close = function () {
        this.WebSocket.close();
    };

    return {
        init: function (options) {
            return new Main(options);
        }
    };
})();