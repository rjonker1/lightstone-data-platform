function initializeRoutes(sammy) {

    sammy.get('/', function (context) {
        this.$element().html('Welcome!');
        context.redirect('#/PreBilling');
    });

    initializePreBilling(sammy);
    initializeStageBilling(sammy);
    initializeFinalBilling(sammy);
    intitializeMI(sammy);
    initializeAdminBilling(sammy);
    initializeAdminAuditLogBilling(sammy);
}

function initializePreBilling(sammy) {

    sammy.get('#/PreBilling', function(context) {
        context.load('/PreBilling', { dataType: 'html', cache: false }).swap();
    });
}

function initializeStageBilling(sammy) {

    sammy.get('#/StageBilling', function (context) {
        context.load('/StageBilling', { dataType: 'html', cache: false }).swap();
    });
}

function initializeFinalBilling(sammy) {

    sammy.get('#/FinalBilling', function (context) {
        context.load('/FinalBilling', { dataType: 'html', cache: false }).swap();
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

function initializeAdminAuditLogBilling(sammy) {
    sammy.get('#/AuditLog', function (context) {
        context.load('/Admin/AuditLog', { dataType: 'html', cache: false }).swap();
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

}