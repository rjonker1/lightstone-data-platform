/**
*	This JSON tool is very nearly completely the work of Vladimir Bodurov
*	the original can be found here :
*		http://quickjsonformatter.codeplex.com/
*			and
*		http://www.bodurov.com/JsonFormatter/
*	
*	The MIT License (MIT)
*	Copyright (c) 2008 Vladimir Bodurov
*	
**/

// spaces are used for tabs to retain format when copying and pasting
window.SINGLE_TAB = "  ";
window.imgPlus = "../assets/images/plus.gif";
window.imgMinus = "../assets/images/minus.gif";
window.QuoteKeys = false;

function $id(id) {
    return document.getElementById(id);
}

function IsArray(obj) {
    return obj && typeof obj === "object" && typeof obj.length === "number" && !(obj.propertyIsEnumerable("length"));
}

function Process(rawJsonId, canvasId) {
    SetTab();
    window.IsCollapsible = true;
    var braceType;
    var json = $id(rawJsonId).value;
    //console.log(json);
    var html = "";
    try {
        if (json == "") json = "\"\"";
        var obj = eval("[" + json + "]");
        html = ProcessObject(obj[0], 0, false, false, false);
        braceType = html.substring(13, 14);
        if (braceType == "A") {
            $id(canvasId).innerHTML = "<PRE class='CodeContainer'>" + "<span class='ArrayBrace'>" + html.substring(26) + "</PRE>";
        }
        else {
            $id(canvasId).innerHTML = "<PRE class='CodeContainer'>" + "<span class='ObjectBrace'>" + html.substring(27) + "</PRE>";
        }
    }
    catch (e) {
        alert("JSON Payload is not well formated :\n" + e.message);
        $id(canvasId).innerHTML = "";
    }
}

window._dateObj = new Date();
window._regexpObj = new RegExp();

function ProcessObject(obj, indent, addComma, isArray, isPropertyContent) {
    var html = "";
    var comma = (addComma) ? "<span class='Comma'>,</span> " : "";
    var type = typeof obj;
    var clpsHtml = "";
    if (IsArray(obj)) {
        if (obj.length == 0) {
            html += GetRow(indent, "<span class='ArrayBrace'>[ ]</span>" + comma, isPropertyContent);
        }
        else {
            clpsHtml = window.IsCollapsible ? "<span><img src=\"" + window.imgMinus + "\" onClick=\"ExpImgClicked( this )\" /></span><span class='collapsible'>" : "";
            html += GetRow(indent, "<span class='ArrayBrace'>\n" + getIndent(indent) + "[</span>" + clpsHtml, isPropertyContent);
            for (var i = 0; i < obj.length; i++) {
                html += ProcessObject(obj[i], indent + 1, i < (obj.length - 1), true, false);
            }
            clpsHtml = window.IsCollapsible ? "</span>" : "";
            html += GetRow(indent, clpsHtml + "<span class='ArrayBrace'>]</span>" + comma);
        }
    }
    else if (type == "object") {
        if (obj == null) {
            html += FormatLiteral("null", "", comma, indent, isArray, "Null");
        }
        else if (obj.constructor == window._dateObj.constructor) {
            html += FormatLiteral("new Date( " + obj.getTime() + " ) /*" + obj.toLocaleString() + "*/", "", comma, indent, isArray, "Date");
        }
        else if (obj.constructor == window._regexpObj.constructor) {
            html += FormatLiteral("new RegExp( " + obj + " )", "", comma, indent, isArray, "RegExp");
        }
        else {
            var numProps = 0;
            for (var prop in obj) numProps++;
            if (numProps == 0) {
                html += GetRow(indent, "<span class='ObjectBrace'>{ }</span>" + comma, isPropertyContent);
            }
            else {
                clpsHtml = window.IsCollapsible ? "<span><img src=\"" + window.imgMinus + "\" onClick=\"ExpImgClicked( this )\" /></span><span class='collapsible'>" : "";
                html += GetRow(indent, "<span class='ObjectBrace'>\n" + getIndent(indent) + "{</span>" + clpsHtml, isPropertyContent);
                var j = 0;
                for (var prop in obj) {
                    var quote = window.QuoteKeys ? "\"" : "";
                    html += GetRow(indent + 1, "<span class='PropertyName'>" + quote + prop + quote + "</span> : " + ProcessObject(obj[prop], indent + 1, ++j < numProps, false, true));
                }
                clpsHtml = window.IsCollapsible ? "</span>" : "";
                html += GetRow(indent, clpsHtml + "<span class='ObjectBrace'>}</span>" + comma);
                //html += GetRow( indent, clpsHtml + "<span class='ObjectBrace'>\n" + getIndent( indent ) + "}</span>" + comma );
            }
        }
    }
    else if (type == "number") {
        html += FormatLiteral(obj, "", comma, indent, isArray, "Number");
    }
    else if (type == "boolean") {
        html += FormatLiteral(obj, "", comma, indent, isArray, "Boolean");
    }
    else if (type == "function") {
        if (obj.constructor == window._regexpObj.constructor) {
            html += FormatLiteral("new RegExp( " + obj + " )", "", comma, indent, isArray, "RegExp");
        }
        else {
            obj = FormatFunction(indent, obj);
            html += FormatLiteral(obj, "", comma, indent, isArray, "Function");
        }
    }
    else if (type == "undefined") {
        html += FormatLiteral("undefined", "", comma, indent, isArray, "Null");
    }
    else {
        html += FormatLiteral(obj.toString().split("\\").join("\\\\").split('"').join('\\"'), "\"", comma, indent, isArray, "String");
    }


    return html;
}

function FormatLiteral(literal, quote, comma, indent, isArray, style) {
    if (typeof literal == "string") literal = literal.split("<").join("&lt;").split(">").join("&gt;");
    var str = "<span class='" + style + "'>" + quote + literal + quote + comma + "</span>";
    if (isArray) str = GetRow(indent, str);
    return str;
}

function FormatFunction(indent, obj) {
    var tabs = "";
    for (var i = 0; i < indent; i++) tabs += window.TAB;
    var funcStrArray = obj.toString().split("\n");
    var str = "";
    for (var i = 0; i < funcStrArray.length; i++) {
        str += ((i == 0) ? "" : tabs) + funcStrArray[i] + "\n";
    }
    return str;
}

function GetRow(indent, data, isPropertyContent) {
    var tabs = "";
    for (var i = 0; i < indent && !isPropertyContent; i++) tabs += window.TAB;
    if (data != null && data.length > 0 && data.charAt(data.length - 1) != "\n") data = data + "\n";
    return tabs + data;
}

function getIndent(indent) {
    var tabs = "";
    for (var i = 0; i < indent; i++) tabs += window.TAB;
    return tabs;
}


function MakeContentVisible(element, visible) {
    var img = element.previousSibling.firstChild;
    if (!!img.tagName && img.tagName.toLowerCase() == "img") {
        element.style.display = visible ? "inline" : "none";
        element.previousSibling.firstChild.src = visible ? window.imgMinus : window.imgPlus;
    }
}

function TraverseChildren(element, func, depth) {
    for (var i = 0; i < element.childNodes.length; i++) {
        TraverseChildren(element.childNodes[i], func, depth + 1);
    }
    func(element, depth);
}

function EnsureIsPopulated(rawJsonId, canvasId) {
    if (!$id(canvasId).innerHTML && !!$id(rawJsonId).value) Process();
}

function CollapseAllClicked(rawJsonId, canvasId) {
    EnsureIsPopulated(rawJsonId, canvasId);
    TraverseChildren($id(canvasId), function (element) {
        if (element.className == "collapsible") {
            MakeContentVisible(element, false);
        }
    }, 0);
}

function ExpandAllClicked(rawJsonId, canvasId) {
    EnsureIsPopulated(rawJsonId, canvasId);
    TraverseChildren($id(canvasId), function (element) {
        if (element.className == "collapsible") {
            MakeContentVisible(element, true);
        }
    }, 0);
}

function ExpImgClicked(img) {
    var container = img.parentNode.nextSibling;
    if (!container) return;
    var disp = "none";
    var src = window.imgPlus;
    if (container.style.display == "none") {
        disp = "inline";
        src = window.imgMinus;
    }
    container.style.display = disp;
    img.src = src;
}

function Toggle(elementId, rawJsonId, canvasId) {
    var ele = document.getElementById(elementId);
    if (ele.style.display === "block") {
        ele.style.display = "none";
        $id(canvasId).innerHTML = "<PRE class='CodeContainer'></PRE>";
    } else {
        ele.style.display = "block";
        src = window.imgMinus;
        Process(rawJsonId, canvasId);
    }
}

function ToggleWithImage(elementId, img, rawJsonId, canvasId) {
    var src = window.imgPlus;
    var ele = document.getElementById(elementId);
    if (ele.style.display === "block") {
        ele.style.display = "none";
        $id(canvasId).innerHTML = "<PRE class='CodeContainer'></PRE>";
    } else {
        ele.style.display = "block";
        src = window.imgMinus;
        Process(rawJsonId, canvasId);
    }

    img.src = src;
}

function SetTab() {
    //var select = $id("TabSize");
    //window.TAB = MultiplyString(parseInt(select.options[select.selectedIndex].value), window.SINGLE_TAB);
    window.TAB = MultiplyString(1, window.SINGLE_TAB);
}

function MultiplyString(num, str) {
    var sb = [];
    for (var i = 0; i < num; i++) {
        sb.push(str);
    }
    return sb.join("");
}

