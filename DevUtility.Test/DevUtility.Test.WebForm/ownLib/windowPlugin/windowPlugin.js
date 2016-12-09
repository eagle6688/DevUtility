;
(function (window, document, undefined) {
    var name = 'windowPlugin',
        version = '1.0.0';

    var plugin = {
        extend : extend,
        browser: {},
        file: {},
        image: {}
    };

    /* extend */

    function extend(source, object) {
        var result = {};

        for (var s in source) {
            if (typeof source[s] == 'object') {
                result[s] = extend(source[s]);
            }
            else {
                result[s] = source[s];
            }
        }

        if (typeof object !== 'undefined' && object !== null) {
            for (var o in object) {
                if (typeof object[o] == 'object') {
                    result[o] = extend(object[o]);
                }
                else {
                    result[o] = object[o];
                }
            }
        }

        return result;
    };

    /* navigator */

    var browser = {};

    browser.getType = function () {
        var defaults = {
            type : '',
            version : ''
        };

        var model = extend(defaults);
        var userAgent = navigator.userAgent.toLowerCase();
        var s;

        if((s = userAgent.match(/msie ([\d.]+)/))){
            model.type = 'MSIE'; 
            model.version = s[1];
            return model;
        }

        if((s = userAgent.match(/firefox\/([\d.]+)/))){
            model.type = 'Firefox'; 
            model.version = s[1];
            return model;
        }

        if((s = userAgent.match(/chrome\/([\d.]+)/))){
            model.type = 'Chrome'; 
            model.version = s[1];
            return model;
        }

        if((s = userAgent.match(/opera.([\d.]+)/))){
            model.type = 'Opera'; 
            model.version = s[1];
            return model;
        }

        if((s = userAgent.match(/version\/([\d.]+).*safari/))){
            model.type = 'Safari'; 
            model.version = s[1];
            return model;
        }

        if(userAgent.indexOf('like gecko') > 0){
            model.type = 'Gecko'; 
            model.version = 0;
            return model;
        }

        return model;
    };

    plugin.browser.getType = browser.getType;

    /* file */

    var file = {};

    file.getFileUrl = function (id) {
        var browserType = browser.getType();
        var input = document.getElementById(id);

        switch (browserType.type) {
            case 'MSIE':
                if(browserType.version == 9.0 && document.selection) {
                    var tempSpan = document.createElement('span');
                    tempSpan.style.zIndex = -1000;
                    tempSpan.style.position = 'absolute';
                    tempSpan.style.top = '0px';
                    tempSpan.style.left = '0px';
                    tempSpan.style.width = 'auto';
                    tempSpan.style.height = 'auto';
                    tempSpan.innerText = 'temp';
                    tempSpan.setAttribute('id', 'span-tempSpan');
                    document.body.appendChild(tempSpan);
                    input.select();
                    tempSpan.focus();
                    var path = document.selection.createRange().text;
                    tempSpan.parentNode.removeChild(tempSpan);
                    return path;
                }
                else if(input.files && input.files.item && window.URL.createObjectURL) {
                    return window.URL.createObjectURL(input.files.item(0));
                }
                else if(document.selection) {
                    input.select();
                    return document.selection.createRange().text;
                }

            case 'Firefox':
                if(browserType.version > 7.0) {
                    return window.URL.createObjectURL(input.files.item(0));
                }
                else {
                    return input.files[0].getAsDataURL();
                }

            case 'Chrome':
                return window.URL.createObjectURL(input.files.item(0));

            case 'Safari':
                return window.URL.createObjectURL(input.files.item(0));

            case 'Gecko':
                return window.URL.createObjectURL(input.files.item(0));

            default:
                return input.value;
        }
    };

    plugin.file.getFileUrl = file.getFileUrl;

    file.getExt = function(id) {
        var input = document.getElementById(id);
        var value = input.value.toLowerCase();
        var index = value.indexOf('.');

        if(index !== -1) {
            var temp = index;

            while(temp != -1 && (temp + 1) < value.length) {
               temp = value.indexOf('.', index + 1);
           
               if(temp != -1) {
                   index = temp;
               }
            }

            return value.substring(index);
        }

        return '';
    };

    plugin.file.getExt = file.getExt;

    file.getSize = function(id, unit) {
        var fileSize = 0;
        var browserType = browser.getType();
        var input = document.getElementById(id);

        if(browserType.type == 'MSIE' && !input.files) {
            var filePath = input.value;
            var fileSystem = new ActiveXObject("Scripting.FileSystemObject");

            if (!fileSystem.FileExists(filePath)) {
                alert("File does not exist!");
                return -1;
            }

            var file = fileSystem.GetFile(filePath);
            fileSize = file.Size;
        }
        else {
            if(!input.files || !input.files[0]) {
                alert("File does not exist!");
                return -1;
            }

            fileSize = input.files[0].size;
        }

        if(unit) {
            switch(unit) {
               case 'mb':
                   fileSize = (fileSize / 1024) / 1024;
                   break;

               case 'kb':
                   fileSize = fileSize / 1024;
                   break;

               case 'gb':
                   fileSize = ((fileSize / 1024) / 1024) / 1024;
                   break;

               default:
                   break;
            }
        }

        return fileSize;
    };

    plugin.file.getSize = file.getSize;

    /* image */

    var image = {};

    image.getWH = function (src, callback) {
        var img = new Image();
        var browserType = browser.getType();

        if (!src || !callback) {
            return false;
        }

        if (browserType.type == 'MSIE') {
            img.onload = function () {
                if (img.complete == true || img.readyState == 'complete') {
                    callback(img);
                }
            };
        }
        else {
            img.onload = function () {
                if (img.complete == true) {
                    callback(img);
                }
            };
        }

        img.src = src;
    };
    
    plugin.image.getWH = image.getWH;
    window[name] = plugin;
})(window, document);