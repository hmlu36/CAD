// 將Json日期轉成日期格式
function Json2Date(str) {
    //alert(str);
    if (str == "/Date(-62135596800000)/") return null;
    return new Date(parseInt(str.substr(6), 10)).f("yyyy/MM/dd");
}

function ISODate2Str(str) {
    return str.substring(0, 10).replace(/-/g, "/");
}

function date2Str(date) {
    var year = date.getFullYear();
    var month = lpad((date.getMonth() + 1), 2, "0");
    var day = lpad(date.getDate(), 2, "0");
    return date ? (year + "/" + month + "/" + day) : "";
}

function parseJsonDate(jsonDateString) {
    return new Date(parseInt(jsonDateString.replace('/Date(', '')));
}


// 任期格式轉換
function parseDate(str) {
    if (!str) return null;
    if (isValidDate(str)) {
        var tempDate = str.split('/');
        var year = tempDate[0]; // alert(year);
        var month = tempDate[1]; // alert(month);
        var day = tempDate[2]; // alert(day);
                
        //please put attention to the month (parts[0]), Javascript counts months from 0
        return new Date(year, month - 1, day);
    }
    return undefined;
}

function range(start, end) {
    return (new Array(end - start + 1)).fill(undefined).map((_, i) => i + start);
}



// 驗證日期
function isValidDate(dateString) {
    if (!/^(\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})$/.test(dateString) || dateString.length != 10) return false;

    var tempDate = dateString.split('/');
    var valid = true;
    var year = tempDate[0]; // alert(year);
    var month = tempDate[1]; // alert(month);
    var day = tempDate[2]; // alert(day);

    if ((month < 1) || (month > 12)) valid = false;
    else if ((day < 1) || (day > 31)) valid = false;
    else if (((month == 4) || (month == 6) || (month == 9) || (month == 11)) && (day > 30)) valid = false;
    else if ((month == 2) && (((year % 400) == 0) || ((year % 4) == 0)) && ((year % 100) != 0) && (day > 29)) valid = false;
    else if ((month == 2) && ((year % 100) == 0) && (day > 29)) valid = false;
    else if ((month == 2) && (day > 28)) valid = false;
    
    return valid;
}

// 金錢符號
function formatNumber(num) {
    return (!num ? 0 : num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,"));
}

// 增加天數
// var dat = new Date();
// alert(dat.addDays(5))
Date.prototype.addDays = function (days) {
    this.setDate(this.getDate() + days);
    return this;
}

Date.prototype.addMonths = function (value) {
    var n = this.getDate();
    this.setDate(1);
    this.setMonth(this.getMonth() + value);
    this.setDate(Math.min(n, this.getDaysInMonth()));
    return this;
};

function pad(number) {
    var r = String(number);
    if (r.length === 1) {
        r = '0' + r;
    }
    return r;
}

Date.prototype.toISOString = function () {
    return this.getUTCFullYear()
        + '-' + pad(this.getUTCMonth() + 1)
        + '-' + pad(this.getUTCDate())
        + 'T' + pad(this.getUTCHours())
        + ':' + pad(this.getUTCMinutes())
        + ':' + pad(this.getUTCSeconds())
        + '.' + String((this.getUTCMilliseconds() / 1000).toFixed(3)).slice(2, 5)
        + 'Z';
};


// left padding s with c to a total of n chars
// lpad('eureka', 10, '*')
function lpad(input, width, padding) {
    var str = '' + input;
    while (str.length < width) {
        str = padding + str;
    }
    return str;
}

// right padding s with c to a total of n chars
// rpad('eureka', '*', 10)
function rpad(s, width, padding) {
    var str = '' + input;
    while (str.length < width) {
        str = str + padding;
     }
    return str;
}

function ddlDescription(jsonArray, compareKey) {
    if (!compareKey) return "";
    var result = jsonArray.filter(function (entry) {
                    return entry["Code"] === compareKey;
                }).map(function (entry) {
                    return entry["Description"];
                });

    return result.toString();
}


function byteLength(str) {
    // returns the byte length of an utf8 string
    var s = str.length;
    for (var i = str.length - 1; i >= 0; i--) {
        var code = str.charCodeAt(i);
        if (code > 0x7f && code <= 0x7ff) s++;
        else if (code > 0x7ff && code <= 0xffff) s += 2;
        if (code >= 0xDC00 && code <= 0xDFFF) i--; //trail surrogate
    }
    return s;
}

function capitalizeFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}