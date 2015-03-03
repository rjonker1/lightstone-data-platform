function initializeRoutes(sammy) {
    
    sammy.get('/', function () {
        this.$element().html('Welcome!');
    });
    
    initializeAuditLogRoutes(sammy);
    initializeCusomerRoutes(sammy);
    initializeClientRoutes(sammy);
    initializeUserRoutes(sammy);
    initializeContractRoutes(sammy);
    initializeLookupRoutes(sammy);
}

function initializeAuditLogRoutes(sammy) {

    sammy.get('/AuditLogs', function (context) {
        context.load('/AuditLogs', { dataType: 'html', cache: false }).swap();
    });

}

function initializeCusomerRoutes(sammy) {

    sammy.get('/Customers', function (context) {
        context.load('/Customers', { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/Customers/Add', function(context) {
        context.load('/Customers/Add', { dataType: 'html', cache: false })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Customers', function(context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Customers');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Customers/:id', function (context) {
        context.load('/Customers/' + context.params.id, { dataType: 'html', cache: false })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    //sammy.put('/Customers/:id', function(context) {
    //    context.load('/Customers/' + context.params.id, { dataType: 'html', cache: false }).swap();
    //    return true; // Allow form submit
    //});
    sammy.post('/Customers/:id', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Customers');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Customers/Delete/:id', function (context) {

        $.ajax({
            type: "DELETE",
            url: '/Customers/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
}

function initializeClientRoutes(sammy) {

    sammy.get('/Clients', function (context) {
        context.load('/Clients', { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/Clients/Add', function (context) {
        context.load('/Clients/Add', { dataType: 'html', cache: false })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Clients', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Clients');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false;
    });
    sammy.get('/Clients/:id', function (context) {
        context.load('/Clients/' + context.params.id, { dataType: 'html', cache: false })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Clients/:id', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Clients');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Clients/Delete/:id', function (context) {

        $.ajax({
            type: "DELETE",
            url: '/Clients/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
}

function initializeUserRoutes(sammy) {
    
    sammy.get('/Users', function (context) {
        context.load('/Users', { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/Users/Add', function (context) {
        context.load('/Users/Add', { dataType: 'html', cache: false })
            .swap()
            .then(function () {
                initializePlugins();
            });
    });
    sammy.post('/Users', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Users');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Users/:id', function (context) {
        context.load('/Users/' + context.params.id, { dataType: 'html', cache: false })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Users/:id', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Users');
            }
        });
        /// !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Users/Delete/:id', function (context) {

        $.ajax({
            type: "DELETE",
            url: '/Users/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
}

function initializeContractRoutes(sammy) {

    sammy.get('/Contracts', function (context) {
        context.load('/Contracts', { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/Contracts/Add', function (context) {
        context.load('/Contracts/Add', { dataType: 'html', cache: false })
            .swap()
            .then(function () {
                initializePlugins();
            });
    });
    sammy.post('/Contracts', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Contracts');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Contracts/:id', function (context) {
        context.load('/Contracts/' + context.params.id, { dataType: 'html', cache: false })
            .swap()
            .then(function () {
                initializePlugins();
            });
    });
    sammy.post('/Contracts/:id', function (context) {
        $(context.target).ajaxSubmit({
            success: function () {
                context.redirect('/#/Contracts');
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
    sammy.get('/Contracts/Delete/:id', function (context) {
        $.ajax({
            type: "DELETE",
            url: '/Contracts/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
}

function initializeLookupRoutes(sammy) {
    sammy.get('/Lookups/:type', function (context) {
        context.load('/Lookups/' + context.params.type, { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/Lookups/Add/:type', function (context) {
        context.load('/Lookups/Add/' + context.params.type, { dataType: 'html', cache: false })
            .swap()
            .then(function () {
                initializePlugins();
            });
    });
    sammy.post('/Lookups', function (context) {
        $(context.target).ajaxSubmit({
            success: function (response) {
                context.redirect('/#/Lookups/' + response);
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false;
    });
    sammy.post('/Lookups/:id', function (context) {
        console.log("TEST");
        $(context.target).ajaxSubmit({
            success: function (response) {
                context.redirect('/#/Lookups/' + response);
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false;
    });
    sammy.get('/Lookups/Delete/:id', function (context) {
        console.log("TEST");

        $.ajax({
            type: "DELETE",
            url: '/Lookups/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
    sammy.get('/Lookups/:type/:filter', function (context) {
        //context.load('/Lookups/' + context.params.type + '/' + , { dataType: 'html', cache: false }).swap();
    });
}

function initializePlugins() {
    $(".chosen-select").chosen({ width: "100%" });
    $('.input-group.date').bootstrapdatepicker({ autoclose: true, format: "yyyy-mm-dd" });
    UserManagement.panelBodyCollapse();
    $('.chosen-autocomplete .chosen-choices input').autocomplete({
        source: function (request, response) {
            var $container = $(this.element).closest('.chosen-autocomplete');
            var type = $container.data('type');
            $.ajax({
                url: "/Lookups/" + type + "/" + request.term + "/",
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
            var $container = $(this).closest('.chosen-autocomplete');
            var $select = $container.find('select');
            $select.append('<option selected="true" value="' + ui.item.value + '">' + ui.item.label + '</option>');
            $select.trigger("chosen:updated");
        }
    });
    
    $('.chosen-autocomplete-packages .chosen-choices input').autocomplete({
        source: function (request, response) {
            var $container = $(this.element).closest('.chosen-autocomplete');
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
            var $container = $(this).closest('.chosen-autocomplete-packages');
            var $select = $container.find('select');
            $select.append('<option selected="true" value="' + ui.item.value + '|' + ui.item.label + '">' + ui.item.label + '</option>');
            $select.trigger("chosen:updated");
        }
    });
    
    $('.auto-list-complete input').autocomplete({
        source: function(request, response) {
            var $container = $(this.element).closest('div');
            var type = $container.data('type');
            //var $ul = $container.find('ul');
            //var $ul = $("<ul>", {
            //    text: "",
            //    "class": "custom-colorize-changer"
            //}).appendTo($container);
            $.ajax({
                url: "/Lookups/" + type + "/" + request.term + "/",
                dataType: "json",
                beforeSend: function() {
                },
                success: function(data) {
                    response($.map(data.dto, function(item) {
                        return {
                            label: item.name,
                            value: item.id
                        };
                    }));
                }
            });
        },
        select: function (event, ui) {
            var $container = $(this).closest('div');
            var $ul = $container.find('ul');
            if ($('#' + ui.item.value).length) {
                return;
            }
            
            var index = $ul.children('li').length;
            var $li = $("<li>", {
                text: ""
            }).appendTo($ul);
            var $id = $("<input>", {
                id: ui.item.value,
                name: "ClientId[" + index + "]",
                value: ui.item.value,
                type: 'hidden'
            }).appendTo($li);
            var $label = $("<label>", {
                text: ui.item.label
            }).appendTo($li);
            var $value = $("<input>", {
                name: "UserAlias[" + index + "]",
                value: "",
                "class": "form-control"
            }).appendTo($li);
        },
        close: function(event, ui) {
            $(this).val('');
        }
    });
}