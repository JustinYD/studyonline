var __global = {
    args: { dft_img: "/Scripts/egov-v1.0/skin/default/dft-img.png" }
};

!function ($) {
    if (!$) return false;
    $(function () {
        var _document = self != top ? top.document : document;
        var _tool_tips_el = $(_document.getElementById("_tips_box"));
        if (_tool_tips_el && _tool_tips_el.length) {
            _tool_tips_el.fadeOut("slow", function () {
                $(this).remove();
            });
        }
    });
} (jQuery);
jQuery.extend({
    //#region 检查邮箱格式
    checkEmail: function (email) {
        return (email.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1);
    },
    //#endregion 

    //#region 检查手机号码格式
    checkPhoneNumber: function (phone) {
        var regPartton = /1[3-8]+\d{9}/;
        return regPartton.test(phone);
    },
    //#endregion 

    //#region 获取URL中的参数
    getQueryString: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    },
    //#endregion 

    //#region 生成GUID
    getGuid: function () {
        var guid = "";
        for (var i = 1; i <= 32; i++) {
            var n = Math.floor(Math.random() * 16.0).toString(16);
            guid += n;
            if ((i == 8) || (i == 12) || (i == 16) || (i == 20))
                guid += "-";
        }
        return guid;
    },
    //#endregion 

    //#region 消息提示
    tips: function (msg, bgColor, timeout, callback) {
        var _id = "_tips_box",
            _el,
            _style = "display:none;position:absolute;top:70px;left:50%;padding:15px 40px;background-color:" + (bgColor || "#ff7f50") + ";border-radius:5px;color:#fff;z-index:900000;font-size:14px;font-family:\"Helvetica Neue\" , Helvetica, Arial, sans-serif;",
            _marginLeft,
            _marginTop,
            _document;
        _document = self != top ? top.document : document;
        if (!_document.getElementById(_id)) $("<div id='" + _id + "'></div>").appendTo(_document.body);
        _el = $(_document.getElementById(_id));
        _el.attr("style", _style).html(msg);
        _marginLeft = _el.outerWidth() / 2;
        _el.css({ marginLeft: -_marginLeft + "px" })
            .stop()
            .fadeIn("slow", function () {
                setTimeout(function () {
                    _el.remove();
                    callback && callback();
                }, timeout || 2000);
            });
    },
    //#endregion

    //#region 截取字符串
    sub: function (str) {
        if (str && str.length > 100) {
            return str.substring(0, 100) + "...";
        }
        return str;
    },
    //#endregion

    //#region 格式化money ,s:money ,type:是否有小数点
    formatMoney: function (s, type) {
        if (/[^0-9\.]/.test(s))
            return "0.00";
        if (s == null || s == "")
            return "0.00";
        s = s.toString().replace(/^(\d*)$/, "$1.");
        s = (s + "00").replace(/(\d*\.\d\d)\d*/, "$1");
        s = s.replace(".", ",");
        var re = /(\d)(\d{3},)/;
        while (re.test(s))
            s = s.replace(re, "$1,$2");
        s = s.replace(/,(\d\d)$/, ".$1");
        if (type == 0) {// 不带小数位(默认是有小数位) 
            var a = s.split(".");
            if (a[1] == "00") {
                s = a[0];
            }
        }
        return s;
    },
    //#endregion

    //#region 阻止事件冒泡
    stopEventBubble: function (event) {
        var e = event || window.event;
        if (e && e.stopPropagation) e.stopPropagation();
        else e.cancelBubble = true;
    },
    //#endregion

    formatDate: function (str) {
        if (!str) return "-";
        var date = str.indexOf(" ") >= 0 ? str.split(" ")[0] : str,
            _separate = date.indexOf("/") >= 0 ? "/" : "-";
        var year = parseInt(date.split(_separate)[0]);
        var month = parseInt(date.split(_separate)[1]);
        var day = parseInt(date.split(_separate)[2]);
        if (month < 10) {
            month = month;
        }
        if (day < 10) {
            day = day;
        }
        return month + "月" + day + "日";
    },

    //#region 格式化日期 yyyy-MM-dd
    subDate: function (str) {
        if (!str) return "";
        str = str.replace(/(T)/g, " ");
        var date = str.indexOf(" ") >= 0 ? str.split(" ")[0] : str,
            _separate = date.indexOf("/") >= 0 ? "/" : "-";
        var year = date.split(_separate)[0];
        var month = date.split(_separate)[1];
        var day = date.split(_separate)[2];
        if (month[0] != "0" && month < 10) {
            month = "0" + month;
        }
        if (day[0] != "0" && day < 10) {
            day = "0" + day;
        }
        return year + "-" + month + "-" + day;
    },
    //#endregion

    //#region 格式化日期 yyyy-MM-dd hh:mm:ss
    subDateTime: function (str) {
        if (!str) return "";
        var date = str.indexOf(" ") >= 0 ? str.split(" ")[0] : str,
            _separate = date.indexOf("/") >= 0 ? "/" : "-";
        var year = date.split(_separate)[0];
        var month = date.split(_separate)[1];
        var day = date.split(_separate)[2];
        if (month < 10) {
            month = "0" + month;
        }
        if (day < 10) {
            day = "0" + day;
        }
        date = year + "-" + month + "-" + day;

        var time = str.split(" ")[1];
        var hour = time.split(":")[0];
        if (hour < 10) {
            time = "0" + time;
        }
        return date + " " + time;
    },
    //#endregion

    //#region 获取当前时间
    getNow: function () {
        var dt = new Date();
        return dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate() + " " + dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
    },
    //#endregion

    //#region html转义
    encode: function (str) {
        if (!str) return "";
        var s = "";
        s = str.replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        s = s.replace(/\n/g, "<br/>");
        return s;
    },
    //#endregion

    //#region html反转义
    decode: function (str) {
        if (!str) return "";
        s = str.replace(/&amp;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        s = s.replace(/&nbsp;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&quot;/g, "\"");
        s = s.replace(/<br\/>/g, "\n");
        return s;
    },
    //#endregion

    //#region 等比例缩放图片
    autoResizeImage: function (maxWidth, maxHeight, src) {
        var img = new Image();
        img.src = src;
        var hRatio;
        var wRatio;
        var Ratio = 1;
        var w = img.width;
        var h = img.height;
        wRatio = maxWidth / w;
        hRatio = maxHeight / h;
        if (maxWidth == 0 && maxHeight == 0) {
            Ratio = 1;
        } else if (maxWidth == 0) {//
            if (hRatio < 1) Ratio = hRatio;
        } else if (maxHeight == 0) {
            if (wRatio < 1) Ratio = wRatio;
        } else if (wRatio < 1 || hRatio < 1) {
            Ratio = (wRatio <= hRatio ? wRatio : hRatio);
        }
        if (Ratio < 1) {
            w = w * Ratio;
            h = h * Ratio;
        }
        $(this).css({ width: w + "px", height: h + "px" });
        //return { width: w, height: h };
    },
    //#endregion

    //#region 身份证号验证
    checkIdCard: function (number) {
        var date, Ai;
        var verify = "10x98765432";
        var Wi = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
        var area = ['', '', '', '', '', '', '', '', '', '', '', '北京', '天津', '河北', '山西', '内蒙古', '', '', '', '', '', '辽宁', '吉林', '黑龙江', '', '', '', '', '', '', '', '上海', '江苏', '浙江', '安微', '福建', '江西', '山东', '', '', '', '河南', '湖北', '湖南', '广东', '广西', '海南', '', '', '', '重庆', '四川', '贵州', '云南', '西藏', '', '', '', '', '', '', '陕西', '甘肃', '青海', '宁夏', '新疆', '', '', '', '', '', '台湾', '', '', '', '', '', '', '', '', '', '香港', '澳门', '', '', '', '', '', '', '', '', '国外'];
        var re = number.match(/^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$/i);
        if (re == null) return false;
        if (re[1] >= area.length || area[re[1]] == "") return false;
        if (re[2].length == 12) {
            Ai = number.substr(0, 17);
            date = [re[9], re[10], re[11]].join("-");
        }
        else {
            Ai = number.substr(0, 6) + "19" + number.substr(6);
            date = ["19" + re[4], re[5], re[6]].join("-");
        }
        if (!this._isDate(date, "ymd")) return false;
        var sum = 0;
        for (var i = 0; i <= 16; i++) {
            sum += Ai.charAt(i) * Wi[i];
        }
        Ai += verify.charAt(sum % 11);
        return (number.length == 15 || number.length == 18 && number == Ai);
    },
    //#endregion

    //#region 判断是否是日期（私有）
    _isDate: function (op, formatString) {
        formatString = formatString || "ymd";
        var m, year, month, day;
        switch (formatString) {
            case "ymd":
                m = op.match(new RegExp("^((\\d{4})|(\\d{2}))([-./])(\\d{1,2})\\4(\\d{1,2})$"));
                if (m == null) return false;
                day = m[6];
                month = m[5] * 1;
                year = (m[2].length == 4) ? m[2] : GetFullYear(parseInt(m[3], 10));
                break;
            case "dmy":
                m = op.match(new RegExp("^(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))$"));
                if (m == null) return false;
                day = m[1];
                month = m[3] * 1;
                year = (m[5].length == 4) ? m[5] : GetFullYear(parseInt(m[6], 10));
                break;
            default:
                break;
        }
        if (!parseInt(month)) return false;
        month = month == 0 ? 12 : month;
        var date = new Date(year, month - 1, day);
        return (typeof (date) == "object" && year == date.getFullYear() && month == (date.getMonth() + 1) && day == date.getDate());
        function GetFullYear(y) { return ((y < 30 ? "20" : "19") + y) | 0; }
    },
    //#endregion

    //#region 动态加载JS文件
    __loadJSFile: function (src, callback) {
        var _script = document.createElement("script");
        _script.type = "text/javascript";
        _script.onload = _script.onreadystatechange = function () {
            if (_script.readyState && _script.readyState != 'loaded' && _script.readyState != 'complete') return;
            _script.onreadystatechange = _script.onload = null;
            callback && callback();
        };
        _script.src = src;
        document.getElementsByTagName('head')[0].appendChild(_script);
    },
    //#endregion

    //#region 全选
    __chooseAll: function (checkbox_name) {
        var inputs = document.getElementsByTagName("input");
        if (checkbox_name == "") {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = true;
                }
            }
        }
        else {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].name == checkbox_name) {
                    inputs[i].checked = true;
                }
            }
        }
    },
    //#endregion

    //#region 反选
    __chooseReverse: function (checkbox_name) {
        var inputs = document.getElementsByTagName("input");
        if (checkbox_name == "") {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (inputs[i].checked == true) {
                        inputs[i].checked = false;
                    }
                    else {
                        inputs[i].checked = true;
                    }
                }
            }
        }
        else {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].name == checkbox_name) {
                    if (inputs[i].checked == true) {
                        inputs[i].checked = false;
                    }
                    else {
                        inputs[i].checked = true;
                    }
                }
            }
        }
    },
    //#endregion

    //#region 全不选
    __chooseNotAll: function (checkbox_name) {
        var inputs = document.getElementsByTagName("input");
        if (checkbox_name == "") {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = false;
                }
            }
        }
        else {
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].name == checkbox_name) {
                    inputs[i].checked = false;
                }
            }
        }
    },
    //#endregion

    //#region 格式化数字, 以万为单位
    formatNumber: function (num) {
        if (!num || isNaN(num)) return 0;
        var _num = num * 0.0001;
        if (_num < 1) return num;
        else {
            if (_num < 1000) return _num.toFixed(1) + "万";
            return parseInt(_num) + "万";
        }
    },
    //#endregion

    //#region 图片预加载
    preLoadingImg: function (obj, src) {
        if (!src) {
            obj.src = __global.args.dft_img;
            return false;
        }
        var _img = new Image();
        _img.src = src;
        if (_img.complete) {
            obj.src = _img.src;
            return false;
        }
        if ($.browser.msie) {
            _img.onreadystatechange = function () {
                if (_img.readyState == "complete" || _img.readyState == "loaded") {
                    obj.src = _img.src;
                }
            }
        }
        else {
            _img.onload = function () {
                obj.src = _img.src;
            }
        }
        _img.onerror = function () {
            obj.src = __global.args.dft_img;
        }
    },
    //#endregion 

    //#region 页面滚动
    scrollTo: function (selector, callback) {
        var _el = $(selector),
            _timer,
            _dead_time = 100,
            _min_dead_time = 10,
            _first_position = document.documentElement.scrollTop || document.body.scrollTop,
            _distance,
            _min_distance = 200,
            _step,
            _top_position,
            _curr_position,
            _scroll_height = $(document).height(),
            _window_height = $(window).height(),
            _runTop = function () {
                _curr_position = document.documentElement.scrollTop || document.body.scrollTop;
                _curr_position += _step;
                if ((_step < 0 && _curr_position >= _top_position) || (_step > 0 && _curr_position <= _top_position)) {
                    if (_step > 0 && (_curr_position + _window_height >= _scroll_height)) {
                        clearInterval(_timer);
                        callback && callback();
                    }
                    window.scrollTo(0, _curr_position);
                }
                else {
                    clearInterval(_timer);
                    callback && callback();
                }
            };
        if (!_el || !_el.length) return false;
        _top_position = _el.offset().top;
        _distance = _top_position - _first_position;

        _step = _distance / (Math.abs(_distance) <= _min_distance ? _min_dead_time : _dead_time);
        _timer = setInterval(_runTop, 1);
    },
    //#endregion

    //#region 回到顶部
    goTop: function () {
        if ($("#go_top").length) $("#go_top").remove();
        $("<a class=\"go_top\" id=\"go_top\" href=\"javascript:;\" title=\"回到顶部\"></a>").appendTo("body")
            .unbind("click").bind("click", function () {
                $.scrollTo("body");
            });

        // 监听滚动条事件
        $(window).scroll(function () {
            var _top = document.documentElement.scrollTop || document.body.scrollTop;
            if (_top <= 250) $("#go_top").hide();
            else $("#go_top").show();
        });
    },
    //#endregion

    //#region 转ASCII码
    toASCII: function (str) {
        if (!str) return "";
        var s = "";
        s = str.replace(/&/g, "&#38;");
        s = s.replace(/</g, "&#60;");
        s = s.replace(/>/g, "&#62;");
        s = s.replace(/ /g, "&#32;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&#34;");
        s = s.replace(/\\/g, "&#92;");
        s = s.replace(/\:/g, "&#58;");
        s = s.replace(/\n/g, "/r/n");
        s = s.replace(/{/g, "&#123;");
        s = s.replace(/}/g, "&#125;");
        s = s.replace(/\^/g, "&#94;");
        s = s.replace(/`/g, "&#60;");
        return s;
    },
    //#endregion

    //#region ASCII转HTML 
    toHtml: function (str) {
        if (!str) return "";
        var s = "";
        s = str.replace(/&#38;/g, "&");
        s = s.replace(/&#60;/g, "<");
        s = s.replace(/&62;/g, ">");
        s = s.replace(/&#32;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&#34;/g, "\"");
        s = s.replace(/&#92;/g, "\\");
        s = s.replace(/&#58;/g, "\:");
        s = s.replace(/\/r\/n/g, "\n");
        s = s.replace(/&#123;/g, "{");
        s = s.replace(/&#125;/g, "}");
        s = s.replace(/&#94;/g, "^");
        s = s.replace(/&#60;/g, "`");
        return s;
    },

    //#endregion

    // #region 格式化行政区划数据(向上递归所有的父级)
    formatRegions: function (region, source) {
        if (!region || !source || (typeof source).toLowerCase() !== "object" || !source.length) return region;
        var i,
            len,
            _setItems = function (_region, _source) {
                var j = 0,
                    l = _source.length;
                for (; j < l; j++) {
                    if (_source[j]["id"].toString().indexOf(_region["id"].toString()) >= 0 && _source[j]["id"] != _region["id"]) {
                        if (!_source[j]["parent"]) _source[j]["parent"] = [];
                        _source[j]["parent"].push(_region);
                    }
                }
                return _source;
            },
            _sort = function (_a, _b) {
                return _a["id"] > _b["id"];
            };
        i = 0;
        len = source.length;
        for (; i < len; i++) {
            region = _setItems(source[i], region);
        }
        i = 0;
        len = region.length;
        for (; i < len; i++) {
            if (region[i]["parent"]) region[i]["parent"].sort(_sort);
        }
        return region;
    },
    sendRequest: function (opts) {
        var _data;
        $.ajax({
            url: opts.url,
            type: "post",
            data: opts.data || {},
            dataType: opts.dataType || "json",
            async: opts.async || true,
            success: function (res) {
                _data = res;
            },
            error: function (err1, err2, err3) {
                _data = null;
            },
            complete: function () {
                opts.callback && opts.callback(_data);
            }
        });
    },
    // 格式化文件大小
    formatFileSize: function (bytes) {
        var sizes = ['B', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'],
            k = 1024,
            i;
        if (!bytes) bytes = 0;
        else {
            if ((typeof bytes).toLowerCase() === "string") bytes = parseInt(bytes);
            if (isNaN(bytes)) bytes = 0;
        }
        if (bytes === 0) return '0 B';
        i = Math.floor(Math.log(bytes) / Math.log(k));
        return (bytes / Math.pow(k, i)).toPrecision(3) + ' ' + sizes[i];
    },
    // 禁止右键以及全选
    banRightAndSelect: function () {
        var _fn = function () {
            window.event.returnValue = false;
            return false;
        };
        document.oncontextmenu = _fn;
        document.onkeydown = function (event) {
            event = event || window.event;
            var code = event.keyCode || event.which;
            if (event.ctrlKey && code === 65) {
                window.event.returnValue = false;
                return false;
            }
        };
        document.ondragstart = _fn;
        document.onselectstart = _fn;
    },
    // 回到顶部
    showScroll: function () {
        var el = arguments.length ? arguments[0] : "#wrap";
        $(el).click(function () {
            $("html,body").animate({ scrollTop: 0 }, 200);
        });
    },
      // 检测是否存在危险字符
    hasInjectionData: function (inputData) {
        var keyRegex = /select|insert|delete|from|count\(|drop table|update|truncate|asc\(|mid\(|char\(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user|""|or|and/,
            charRexex = /\-|\;|\,|\/|\(|\)|\[|\]|\}|\{|\%|\@|\*|\!|\'/;
        return keyRegex.test(inputData) && charRexex.test(inputData);
    }
});