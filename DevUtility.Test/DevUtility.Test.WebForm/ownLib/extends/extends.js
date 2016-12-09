(function (window, document, undefined) {
    var version = '20160913';

    Date.prototype.toFormatString = function (format) {
        var time = this;
        var year = time.getFullYear();

        var month = time.getMonth() + 1;
        var monthStr = (month < 10 ? '0' : '') + month;

        var day = time.getDate();
        var dayStr = (day < 10 ? '0' : '') + day;

        var hour = time.getHours();
        var hourStr = (hour < 10 ? '0' : '') + hour;

        var minute = time.getMinutes();
        var mintueStr = (minute < 10 ? '0' : '') + minute;

        var second = time.getSeconds();
        var secondStr = (second < 10 ? '0' : '') + second;

        switch (format) {
            case 'yyyy-mm-dd':
                return year + '-' + monthStr + '-' + dayStr;

            case 'yyyy/mm/dd':
                return year + '/' + monthStr + '/' + dayStr;

            case 'yyyy-mm-dd hh:mm:ss':
                return year + '-' + monthStr + '-' + dayStr + ' ' + hourStr + ':' + mintueStr + ':' + secondStr;

            default:
                return time.toString();
        }
    };

    Date.prototype.getPart = function (format) {
        var dateStr = this.toFormatString(format);
        return dateStr.toTime(format);
    };

    Date.prototype.compareTo = function (time) {
        return this.getTime() - time.getTime();
    };

    Date.prototype.isWeekend = function () {
        var day = this.getDay();

        if (day === 0 || day === 6) {
            return true;
        }
        else {
            return false;
        }
    };

    Date.prototype.isSameDay = function (time) {
        var thisDate = this.getPart('yyyy-mm-dd');
        var date = time.getPart('yyyy-mm-dd');
        return thisDate.compareTo(date) === 0;
    };

    Date.prototype.isToday = function () {
        var currentTime = new Date();
        return this.isSameDay(currentTime);
    };

    Date.prototype.addHours = function (hours) {
        var millisecond = this.getTime();
        var millisecondResult = millisecond + hours * 60 * 60 * 1000;
        var result = new Date(millisecondResult);
        return result;
    };

    Date.prototype.addDays = function (days) {
        var millisecond = this.getTime();
        var millisecondResult = millisecond + days * 24 * 60 * 60 * 1000;
        var result = new Date(millisecondResult);
        return result;
    };

    Date.prototype.addMonths = function (months) {
        var year = this.getFullYear();
        var month = this.getMonth();
        var monthResult = month + months;
        var day = this.getDate();

        if (monthResult > 11) {
            year++;
            month = monthResult - 12;
        }
        else if (monthResult < 0) {
            year--;
            month = 12 + monthResult;
        }
        else {
            month = monthResult;
        }

        var result = new Date(year, month, day);
        return result;
    };

    Array.prototype.contain = function (value) {
        var array = this;

        if (array) {
            for (var i = 0; i < array.length; i++) {
                if (array[i] === value) {
                    return true;
                }
            }
        }

        return false;
    };

    String.prototype.format = function (args) {
        var result = this;

        if (arguments.length > 0) {
            if (arguments.length === 1 && typeof (args) === "object") {
                for (var key in args) {
                    if (args[key] !== undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            }
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] !== undefined) {
                        var reg = new RegExp("({[" + i + "]})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }

        return result;
    };

    String.prototype.isWeekend = function () {
        var time = this.toTime('yyyy-mm-dd');
        return time.isWeekend();
    };

    String.prototype.toTime = function (format) {
        var time = this.toLowerCase();
        var array = new Array();

        switch (format.toLowerCase()) {
            case 'yyyy-mm-dd':
                array = time.split('-');
                break;

            case 'yyyy/mm/dd':
                array = time.split('/');
                break;

            case 'yyyy-mm-dd hh:mm':
                {
                    var array1 = time.split(' ');
                    var array2 = array1[1].split(':');
                    var date = array1[0].toTime('yyyy-mm-dd');
                    date.setHours(~~array2[0]);
                    date.setMinutes(~~array2[1]);
                    return date;
                }

            case 'yyyy-mm-ddthh:mm:ss.ccc':
                {
                    var array1 = time.split('t');
                    var array2 = array1[1].split('.');
                    var dateArray = array1[0].split('-');
                    var timeArray = array2[0].split(':');
                    array.push(dateArray);
                    array.push(timeArray);
                }
                break;
        }

        if (array.length === 3) {
            var year = parseInt(array[0]);
            var month = parseInt(array[1].trimZero()) - 1;
            var day = parseInt(array[2].trimZero());
            return new Date(year, month, day);
        }
        else if (array.length === 2) {
            var year = parseInt(array[0][0]);
            var month = parseInt(array[0][1].trimZero()) - 1;
            var day = parseInt(array[0][2].trimZero());
            var hour = parseInt(array[1][0].trimZero());
            var minute = parseInt(array[1][1].trimZero());
            var second = parseInt(array[1][2].trimZero());
            return new Date(year, month, day, hour, minute, second);
        }

        return null;
    };

    String.prototype.trimZero = function () {
        var str = this;

        if (str !== '00' && str.indexOf('0') === 0) {
            str = str.substring(1, str.length);
            str = str.trimZero();
        }

        return str;
    };

    Number.prototype.toHourAndMinute = function () {
        var number = this;

        if (number > 9) {
            return number.toString() + ':00';
        }

        return '0' + number.toString() + ':00';
    };
})(window, document);