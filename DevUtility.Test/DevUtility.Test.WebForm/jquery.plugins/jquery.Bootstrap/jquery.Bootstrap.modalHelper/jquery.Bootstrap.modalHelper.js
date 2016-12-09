;
(function ($, window, document, undefined) {
    var pluginName = 'bootstrap_ModalHelper',
        version = '20151210';

    var defaults = {
        url: '', //content page url
        title: 'modal',
        saveButtonText: 'Save',
        closeButtonText: 'Close',
        saveEvent: function () { },
        closeEvent: function () { },
        afterLoad: function () { }
    };

    function Plugin(element, options) {
        this.element = element;
        this.$element = $(element);
        this.elementID = this.$element.attr('id');
        this.options = $.extend(true, {}, defaults, options);
        this.init();
    };

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype.init = function () {
        if (!this.verify()) {
            return;
        }

        this.createModal();
        this.register();

    };

    Plugin.prototype.verify = function () {
        if (!this.options.url) {
            throw ('url is empty!');
            return false;
        }

        return true;
    };

    Plugin.prototype.createModal = function () {
        this.$modal = $('<div class="modal fade" tabindex="-1" role="dialog" aria-hidden="true"></div>');
        this.$modal.attr('id', this.elementID);

        var $dialog = $('<div class="modal-dialog"></div>');
        this.$modal.append($dialog);

        var $content = $('<div class="modal-content"></div>');
        $dialog.append($content);

        var $header = $('<div class="modal-header"></div>');
        this.$closeButton = $('<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>');
        $header.append(this.$closeButton);

        var $title = $('<h4 class="modal-title"></h4>').html(this.options.title);
        $header.append($title);
        $content.append($header);

        this.$body = $('<div class="modal-body"></div>');
        $content.append(this.$body);

        var $footer = $('<div class="modal-footer"></div>');
        this.$cancelButton = $('<button type="button" class="btn btn-default" data-dismiss="modal"></button>').html(this.options.closeButtonText);
        $footer.append(this.$cancelButton);

        this.$saveButton = $('<button type="button" class="btn btn-primary"></button>').text(this.options.saveButtonText);
        $footer.append(this.$saveButton);
        $content.append($footer);
        this.$element.replaceWith(this.$modal);
    };

    Plugin.prototype.register = function () {
        var that = this;

        this.$saveButton.click(function (event) {
            that.saveEvent();
        });

        this.$closeButton.click(function (event) {
            that.closeEvent();
        });

        this.$cancelButton.click(function (event) {
            that.closeEvent();
        });

        this.$modal.on('show.bs.modal', function (event) {
            that.setZIndex();
            that.loadBody();
        });
    };

    Plugin.prototype.loadBody = function () {
        var that = this;

        $.get(this.options.url, function (result) {
            that.$body.html(result);

            if (that.options.afterLoad) {
                that.options.afterLoad();
            }
        });
    };

    Plugin.prototype.setZIndex = function () {
        var index = this.getZIndex();

        if (index > 1) {
            this.$modal.css('z-index', index);
        }
    };

    Plugin.prototype.getZIndex = function () {
        var maxIndex = 0;

        $('.modal').each(function () {
            var index = ~~$(this).css('z-index');

            if (index > maxIndex) {
                maxIndex = index;
            }
        });

        return maxIndex + 1;
    };

    Plugin.prototype.saveEvent = function () {
        if (this.options.saveEvent) {
            this.options.saveEvent();
        }
    };

    Plugin.prototype.closeEvent = function () {
        if (this.options.closeEvent) {
            this.options.closeEvent();
        }
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            new Plugin(this, options);
        });
    };
})(jQuery, window, document);