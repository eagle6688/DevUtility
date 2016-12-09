;
(function ($, window, document, undefined) {
    var pluginName = 'browseProduct',
        version = '20151027';

    var defaults = {
        data: null,
        levels: 4, //levels count that need to display, 1-4
        selected: function (productType, serie, subSerie, machineType) { }, //selected event,
        redirect: function (url) { }, //redirect event
        isCascadeShow: true,
        translator: [], //translator array
        translatorNames: {
            title: 'Browse products',
            selectSeries: 'Select Series',
            selectSubSeries: 'Select Sub Series',
            selectMachineType: 'Select Machine Type'
        },
        linksFormat: [
            '&product&',
            '&product&/&serie&',
            '&product&/&serie&/&subserie&',
            '&product&/&serie&/&subserie&/&machinetype&'
        ],
        productsContainerConfig: {
            productsContainerClass: 'prods-module',
            productConfig: {
                productClass: 'prod-item slick-slide slick-active',
                clickEvent: null
            }
        },
        selectorContainerConfig: {
            selectorContainerClass: 'series-container',
            selectorConfig: {
                selectorClass: 'wrapper-dropdown',
                dropDownListClass: 'dropdown',
                clickEvent: null,
                selectorItemsConfig: {
                    itemClass: 'ps_link',
                    clickEvent: null
                }
            }
        },
        slickConfig: {
            dots: false,
            infinite: false,
            speed: 300,
            slidesToShow: 7,
            centerMode: false,
            variableWidth: true,
            responsive: [
              {
                  breakpoint: 1500,
                  settings: {
                      slidesToShow: 6,
                      dots: false
                  }
              },
              {
                  breakpoint: 1220,
                  settings: {
                      slidesToShow: 5,
                      dots: false
                  }
              },
              {
                  breakpoint: 1000,
                  settings: {
                      slidesToShow: 4,
                      dots: false
                  }
              },
              {
                  breakpoint: 950,
                  settings: {
                      slidesToShow: 3,
                      dots: false
                  }
              },
              {
                  breakpoint: 500,
                  settings: {
                      slidesToShow: 2,
                      dots: false
                  }
              }
            ]
        }
    };

    function Plugin(element, options) {
        this.selectedValues = {
            productType: '',
            serie: '',
            subSerie: '',
            machineType: '',
            currentLevel: 0,
            nextLevelData: null
        };

        this.$element = $(element);
        this.options = $.extend(true, {}, defaults, options);

        this.$title = $('<h2></h2>');
        this.$productsContainer = $('<div></div>');

        this.verifyOptions();
        this.load();
        this.register();
    };

    Plugin.prototype.constructor = Plugin;

    Plugin.prototype.verifyOptions = function () {
        if (!this.options.data || this.options.data.length == 0) {
            throw 'data is null';
        }

        if (!this.options.translator || this.options.translator.length == 0) {
            throw 'translator is null';
        }
    };

    Plugin.prototype.load = function () {
        this.loadTitle();
        this.loadProductsContainer();
        this.loadSelectorContainer();
    };

    Plugin.prototype.loadTitle = function () {
        this.$title.html(this.getTranslatedValue(this.options.translatorNames.title));
        this.$element.append(this.$title);
    };

    Plugin.prototype.loadProductsContainer = function () {
        var that = this;

        this.options.productsContainerConfig.clickEvent = function (value) {
            that.clickProduct(value);
        };

        this.productsContainer = new ProductsContainer(this.options);
        this.$element.append(this.productsContainer.$body);
    };

    Plugin.prototype.loadSelectorContainer = function () {
        var that = this;

        this.options.selectorContainerConfig.clickEvent = function (selectedValues) {
            that.clickSelector(selectedValues);
        };

        this.selectorsContainer = new SelectorContainer(this.options);
        this.$element.append(this.selectorsContainer.$body);
    };

    Plugin.prototype.register = function () {
        var that = this;

        $('body').click(function (event) {
            that.productsContainer.reset();
            that.selectorsContainer.hide();
        });
    };

    Plugin.prototype.initSelectedValues = function () {
        this.selectedValues.productType = '';
        this.selectedValues.serie = '';
        this.selectedValues.subSerie = '';
        this.selectedValues.machineType = '';
    };

    Plugin.prototype.getTranslatedValue = function (name) {
        return this.options.translator[name];
    };

    //Plugin events

    Plugin.prototype.redirect = function () {
        if (this.selectedValues.currentLevel < 1 || this.selectedValues.currentLevel > 4) {
            throw ('currentLevel error');
            return;
        }

        var urlFormat = this.options.linksFormat[(this.selectedValues.currentLevel - 1)];

        if (!urlFormat) {
            return;
        }

        if (this.selectedValues.nextLevelData && this.selectedValues.nextLevelData.length > 0 && this.selectedValues.currentLevel != this.options.levels) {
            return;
        }

        var url = this.getUrl(urlFormat);

        if (!url) {
            return;
        }

        if (this.options.redirect) {
            this.options.redirect(url);
        }
    };

    Plugin.prototype.getUrl = function (urlFormat) {
        var url = urlFormat.replace(/&product&/g, this.selectedValues.productType);
        url = url.replace(/&serie&/g, this.selectedValues.serie);
        url = url.replace(/&subserie&/g, this.selectedValues.subSerie);
        url = url.replace(/&machinetype&/g, this.selectedValues.machineType);
        return url;
    };

    Plugin.prototype.clickProduct = function (value) {
        this.initSelectedValues();
        this.selectedValues.productType = value;
        this.selectedValues.currentLevel = 1;

        var list = getSelectorData(this.options.data, value);
        this.selectedValues.nextLevelData = list;

        if (this.options.levels > 1) {
            this.selectorsContainer.init();
            this.selectorsContainer.seriesSelector.bindData(list);
            this.selectorsContainer.$body.fadeIn();
        }

        this.selected();
    };

    Plugin.prototype.clickSelector = function (selectedValues) {
        this.selectedValues.serie = selectedValues.serie;
        this.selectedValues.subSerie = selectedValues.subSerie;
        this.selectedValues.machineType = selectedValues.machineType;
        this.selectedValues.currentLevel = selectedValues.currentLevel;
        this.selectedValues.nextLevelData = selectedValues.nextLevelData;
        this.selected();
    };

    Plugin.prototype.selected = function () {
        if (this.options.selected) {
            this.options.selected(this.selectedValues);
        }

        this.redirect();
    };

    //ProductsContainer

    function ProductsContainer(options) {
        this.options = options;
        this.products = [];
        this.$body = $('<div></div>');

        this.load();
        this.init();
        this.bindData();
        this.register();
    };

    ProductsContainer.prototype.load = function () {
        var that = this;
        this.$body.addClass(this.options.productsContainerConfig.productsContainerClass);

        this.options.productsContainerConfig.productConfig.clickEvent = function (value) {
            $('html, body').animate({ scrollTop: that.$body.offset().top - 100 }, 550);

            for (var i = 0; i < that.products.length; i++) {
                if (that.products[i].value != value) {
                    that.products[i].$body.removeClass('active').addClass('dimmed');
                }
            }

            that.clickEvent(value);
        };
    };

    ProductsContainer.prototype.init = function () {
        this.$body.empty();
        this.products = [];
    };

    ProductsContainer.prototype.bindData = function () {
        var products = getProductsData(this.options.data);

        for (var i = 0; i < products.length; i++) {
            this.add(products[i]);
        }
    };

    ProductsContainer.prototype.add = function (data) {
        var product = new Product(this.options, data);
        this.products.push(product);
        this.$body.append(product.$body);
    };

    ProductsContainer.prototype.register = function () {
        var that = this;

        this.$body.on('init', function (slick) {
            that.$body.find('div').each(function (i) {
                $(this).delay((i++) * 30).fadeTo(90, 1);
            });
        }).on('setPosition', function (slick) {
            that.$body.find('div').each(function (i) {
                $(this).delay((i++) * 30).fadeTo(90, 1);
            });
        }).slick(that.options.slickConfig);
    };

    ProductsContainer.prototype.clickEvent = function (value) {
        if (this.options.productsContainerConfig.clickEvent) {
            this.options.productsContainerConfig.clickEvent(value);
        }
    };

    ProductsContainer.prototype.reset = function () {
        for (var i = 0; i < this.products.length; i++) {
            this.products[i].$body.removeClass('active dimmed');
        }
    };

    //Product

    function Product(options, data) {
        this.options = options;
        this.data = data;
        this.value = '';
        this.$body = $('<div style="text-transform: capitalize; opacity: 1;"></div>');

        this.load();
        this.bindData();
        this.bindEvent();
    };

    Product.prototype.load = function () {
        this.$body.addClass(this.options.productsContainerConfig.productConfig.productClass);
    };

    Product.prototype.bindData = function () {
        var data = this.data;
        this.value = data.ProductType;
        this.$body.attr('data-value', this.value);
        this.$body.append($('<div style="margin: 10px 40px; opacity: 1;"></div>').addClass(data.ClassName));
        this.$body.append($('<div class="product-label" style="opacity: 1;"></div>').html(data.ProductName));
    };

    Product.prototype.bindEvent = function () {
        var that = this;

        this.$body.click(function (event) {
            event.stopPropagation();
            $(this).addClass('active');

            if (that.options.productsContainerConfig.productConfig.clickEvent) {
                that.options.productsContainerConfig.productConfig.clickEvent(that.value);
            }
        });
    };

    //SelectorContainer

    function SelectorContainer(options) {
        this.selectedValues = {
            serie: '',
            subSerie: '',
            machineType: '',
            currentLevel: 0,
            nextLevelData: null
        };

        this.options = options;
        this.$body = $('<div></div>');
        this.load();
    };

    SelectorContainer.prototype.load = function () {
        this.$body.addClass(this.options.selectorContainerConfig.selectorContainerClass);
        this.loadSeriesSelector();
        this.loadSubSeriesSelector();
        this.loadMachineTypeSelector();
    };

    SelectorContainer.prototype.loadSeriesSelector = function () {
        var that = this;
        var options = $.extend(true, {}, {}, this.options);
        options.selectorContainerConfig.selectorConfig.translatorName = options.translatorNames.selectSeries;

        options.selectorContainerConfig.selectorConfig.clickEvent = function (text, value) {
            that.selectedValues.serie = value;
            that.selectedValues.currentLevel = 2;

            that.selectedValues.subSerie = '';
            that.subSeriesSelector.init();

            that.selectedValues.machineType = '';
            that.machineTypeSelector.initMachineTypeSelector();

            var list = getSelectorData(options.data, value);
            that.selectedValues.nextLevelData = list;

            if (options.levels > 2) {
                that.subSeriesSelector.setSelected(options.translator[options.translatorNames.selectSubSeries], '');
                that.machineTypeSelector.setSelected(options.translator[options.translatorNames.selectMachineType], '');
                that.subSeriesSelector.bindData(list);
            }

            that.clickEvent();
        };

        this.seriesSelector = new SeriesSelector(options);
        this.$body.append(this.seriesSelector.$body);
    };

    SelectorContainer.prototype.loadSubSeriesSelector = function () {
        var that = this;
        var options = $.extend(true, {}, {}, this.options);
        options.selectorContainerConfig.selectorConfig.translatorName = options.translatorNames.selectSubSeries;

        options.selectorContainerConfig.selectorConfig.clickEvent = function (text, value) {
            that.selectedValues.subSerie = value;
            that.selectedValues.currentLevel = 3;
            that.selectedValues.machineType = '';
            that.machineTypeSelector.initMachineTypeSelector();

            var list = getSelectorData(options.data, value);
            that.selectedValues.nextLevelData = list;

            if (options.levels > 3) {
                that.machineTypeSelector.setSelected(options.translator[options.translatorNames.selectMachineType], '');
                that.machineTypeSelector.bindData(list);
            }

            that.clickEvent();
        };

        this.subSeriesSelector = new SubSeriesSelector(options);
        this.subSeriesSelector.$body.addClass('disabled');
        this.$body.append(this.subSeriesSelector.$body);
    };

    SelectorContainer.prototype.loadMachineTypeSelector = function () {
        var that = this;
        var options = $.extend(true, {}, {}, this.options);
        options.selectorContainerConfig.selectorConfig.translatorName = options.translatorNames.selectMachineType;

        options.selectorContainerConfig.selectorConfig.clickEvent = function (text, value) {
            that.selectedValues.machineType = value;
            that.selectedValues.currentLevel = 4;
            that.selectedValues.nextLevelData = null;
            that.clickEvent();
        };

        this.machineTypeSelector = new MachineTypeSelector(options);
        this.machineTypeSelector.$body.addClass('disabled').hide();
        this.$body.append(this.machineTypeSelector.$body);
    };

    SelectorContainer.prototype.init = function () {
        this.seriesSelector.init();
        this.subSeriesSelector.init(true);
        this.machineTypeSelector.initMachineTypeSelector();
    };

    SelectorContainer.prototype.clickEvent = function () {
        if (this.options.selectorContainerConfig.clickEvent) {
            this.options.selectorContainerConfig.clickEvent(this.selectedValues);
        }
    };

    SelectorContainer.prototype.hide = function () {
        this.seriesSelector.$body.removeClass('active');
        this.subSeriesSelector.$body.removeClass('active')
        this.machineTypeSelector.$body.removeClass('active');
        this.$body.fadeOut();
    };

    //Selector

    function Selector() {
        this.selectedValue = '';
        this.SelectedText = '';
        this.options = {};
        this.$body = $('<div></div>');
        this.$selectedText = $('<span style="text-transform: capitalize;"></span>');
        this.$dropDownList = $('<ul></ul>');
    };

    Selector.prototype.load = function (options) {
        var that = this;
        this.options = options;

        this.options.selectorContainerConfig.selectorConfig.selectorItemsConfig.clickEvent = function (text, value) {
            that.clickEvent(text, value);
        };

        this.$body.addClass(this.options.selectorContainerConfig.selectorConfig.selectorClass).empty();
        this.$body.append(this.$selectedText);

        this.$dropDownList.addClass(this.options.selectorContainerConfig.selectorConfig.dropDownListClass);
        this.$body.append(this.$dropDownList);

        this.init();
        this.bindEvent();
    };

    Selector.prototype.init = function (disabled) {
        if (disabled) {
            this.$body.addClass('disabled');
        }

        this.setSelected(this.options.translator[this.options.selectorContainerConfig.selectorConfig.translatorName], '');
        this.$dropDownList.empty();
    };

    Selector.prototype.bindEvent = function () {
        this.$body.click(function (event) {
            event.stopPropagation();

            if (!$(this).hasClass('disabled')) {
                $(this).toggleClass('active');
            }
        });
    };

    Selector.prototype.setSelected = function (text, value) {
        this.selectedText = text;
        this.selectedValue = value;
        this.$selectedText.text(this.selectedText);
    };

    Selector.prototype.addItem = function (text, value) {
        var item = new SelectorItem(this.options);
        item.set(text, value);
        this.$dropDownList.append(item.$body);
    };

    Selector.prototype.clickEvent = function (text, value) {
        this.setSelected(text, value);

        if (this.options.selectorContainerConfig.selectorConfig.clickEvent) {
            this.options.selectorContainerConfig.selectorConfig.clickEvent(this.selectedText, this.selectedValue);
        }
    };

    //SeriesSelector

    function SeriesSelector(options) {
        Selector.call(this);
        this.load(options);
    };

    SeriesSelector.prototype = new Selector();

    SeriesSelector.prototype.bindData = function (list) {
        this.init();

        for (var i = 0; i < list.length; i++) {
            this.addItem(list[i].ProductName, list[i].Series);
        }
    };

    //SubSeriesSelector

    function SubSeriesSelector(options) {
        Selector.call(this);
        this.load(options);
    };

    SubSeriesSelector.prototype = new Selector();

    SubSeriesSelector.prototype.bindData = function (list) {
        this.init();

        for (var i = 0; i < list.length; i++) {
            this.addItem(list[i].ProductName, list[i].Subseries);
        }

        this.$body.removeClass('disabled');
    };

    //MachineTypeSelector

    function MachineTypeSelector(options) {
        Selector.call(this);
        this.load(options);
    };

    MachineTypeSelector.prototype = new Selector();

    MachineTypeSelector.prototype.initMachineTypeSelector = function () {
        this.init(true);
        this.$body.hide();
    };

    MachineTypeSelector.prototype.bindData = function (list) {
        this.init();

        for (var i = 0; i < list.length; i++) {
            this.addItem(list[i].ProductName, list[i].MachineType);
        }

        this.$body.removeClass('disabled');

        if (list && list.length > 0) {
            this.$body.show();
        }
    };

    //SelectorItem

    function SelectorItem(options) {
        this.options = options;
        this.$body = $('<li></li>');
        this.$link = $('<a style="text-transform: capitalize;" href="javascript: void(0);"></a>');

        this.text = '';
        this.value = '';

        this.load();
        this.bindEvent();
    };

    SelectorItem.prototype.load = function () {
        this.$body.append(this.$link);

        if (this.options.selectorContainerConfig.selectorConfig.selectorItemsConfig.itemClass) {
            this.$link.addClass(this.options.selectorContainerConfig.selectorConfig.selectorItemsConfig.itemClass);
        }
    };

    SelectorItem.prototype.bindEvent = function () {
        var that = this;

        this.$link.click(function () {
            if (that.options.selectorContainerConfig.selectorConfig.selectorItemsConfig.clickEvent) {
                that.options.selectorContainerConfig.selectorConfig.selectorItemsConfig.clickEvent(that.text, that.value);
            }
        });
    };

    SelectorItem.prototype.set = function (text, value) {
        this.text = text;
        this.value = value;
        this.$link.text(this.text);
        this.$link.attr('data-value', this.value);
    };

    //data

    var getProductsData = function (data) {
        var array = new Array();

        for (i = 0; i < data.length; i++) {
            if (!data[i].p) {
                array.push(data[i]);
            }
        }

        return array;
    };

    var getSelectorData = function (data, parent) {
        var array = new Array();

        for (i = 0; i < data.length; i++) {
            if (data[i].p == parent) {
                array.push(data[i]);
            }
        }

        return array;
    };

    $.fn[pluginName] = function (options) {
        return this.each(function () {
            if (!$(this).data(pluginName)) {
                $(this).data(pluginName, new Plugin(this, options));
            }
        });
    };
})(jQuery, window, document);