function initializeRoutes(sammy) {

    sammy.get('/', function () {
        this.$element().html('Welcome!');
    });

    initializePreBilling(sammy);
    intitializeMI(sammy);
    initializeAdminBilling(sammy);
}

function initializePreBilling(sammy) {

    sammy.get('#/PreBilling', function(context) {
        context.load('/PreBilling', { dataType: 'html', cache: false }).swap();
    });
}

function intitializeMI(sammy) {

    sammy.get('#/MI', function(context) {
        context.load('/MI', { dataType: 'html', cache: false }).swap();
    });
}

function initializeAdminBilling(sammy) {
    sammy.get('#/AdminBilling', function(context) {
        context.load('/Admin/Billing', { dataType: 'html', cache: false }).swap();
    });
}

function initializePlugins() {
    $(".chosen-select").chosen({ width: "100%" });
    $('.input-group.date').bootstrapdatepicker({ autoclose: true, format: "yyyy-mm-dd" });
    Billing.panelBodyCollapse();

    $('.entity-autocomplete .chosen-choices input').autocomplete({
        source: function (request, response) {
            var $container = $(this.element).closest('.entity-autocomplete');
            var url = $container.data('url');
            var type = $container.data('type');
            $.ajax({
                url: url + "/" + type + "/" + request.term + "/",
                dataType: "json",
                beforeSend: function () { $('ul.chosen-results').empty(); },
                success: function (data) {
                    response($.map(data.dto, function (item) {
                        return {
                            label: item.name,
                            value: item.id
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            var $container = $(this).closest('.entity-autocomplete');
            var $select = $container.find('select');
            $select.append('<option selected="true" value="' + ui.item.value + '">' + ui.item.label + '</option>');
            $select.trigger("chosen:updated");
        }
    });

    $('.packag-autocomplete .chosen-choices input').autocomplete({
        source: function (request, response) {
            var $container = $(this.element).closest('.packag-autocomplete');
            var type = $container.data('type');
            $.ajax({
                url: "/packages/" + request.term + "/",
                dataType: "json",
                beforeSend: function () { $('ul.chosen-results').empty(); },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.name,
                            value: item.packageId
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            if ($('#' + ui.item.value).length) {
                return;
            }
            var $container = $(this).closest('.packag-autocomplete');
            var $select = $container.find('select');
            $select.append('<option id="' + ui.item.value + '" selected="true" value="' + ui.item.value + '|' + ui.item.label + '">' + ui.item.label + '</option>');
            $select.trigger("chosen:updated");
        }
    });

    $('#ClientIds').autocomplete({
        source: function (request, response) {
            var $container = $(this.element).closest('div');
            var type = $container.data('type');
            //var $ul = $container.find('ul');
            //var $ul = $("<ul>", {
            //    text: "",
            //    "class": "custom-colorize-changer"
            //}).appendTo($container);
            $.ajax({
                url: "/NamedEntities/" + type + "/" + request.term + "/",
                dataType: "json",
                beforeSend: function () {
                },
                success: function (data) {
                    response($.map(data.dto, function (item) {
                        return {
                            label: item.name,
                            value: item.id
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            if ($('#' + ui.item.value).length) {
                return;
            }

            var $container = $(this).closest('div');
            var $listGroup = $container.find('.list-group');

            var $item = $("<div>", { "class": "list-group-item" }).appendTo($listGroup);

            var $left = $("<div>", { "class": "pull-left" }).appendTo($item);
            var $remove = $("<a>", { "class": "btn btn-danger btn-xs close-box", href: "javascript:;" }).appendTo($left);
            var $removeIcon = $("<i>", { "class": "fa fa-times" }).appendTo($remove);

            var index = $listGroup.children('li').length;

            var $id = $("<input>", {
                id: ui.item.value,
                name: "ClientId[" + index + "]",
                value: ui.item.value,
                type: 'hidden'
            }).appendTo($item);

            var $label = $("<label>", { text: ui.item.label }).appendTo($item);

            var $value = $("<input>", {
                name: "UserAlias[" + index + "]",
                value: "",
                "class": "form-control"
            }).appendTo($item);
        },
        close: function (event, ui) {
            $(this).val('');
        }
    });
}