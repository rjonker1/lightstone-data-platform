$(document).ready(function () {
    $("#loading").hide();
    $("#mask").fadeIn();

    Globalize.culture("en-ZA");

    $("input[data-val-date]").datepicker();
    $.datepicker.setDefaults($.datepicker.regional["en"]);

    $.validator.methods.number = function (value, element) {
        var val = Globalize.parseFloat(value);
        return this.optional(element) || ($.isNumeric(val));
    };
    $.validator.methods.date = function (value, element) {
        var val = Globalize.parseDate(value);
        return this.optional(element) || (val);
    };
});

$(document).ajaxError(function (e, xhr) {
    window.location = '@Url.Action("Index", "Home")';
});