function initializeRoutes(sammy) {
    
    sammy.get('/', function () {
        this.$element().html('Welcome!');
    });
    
    initializeCusomerRoutes(sammy);
    initializeClientRoutes(sammy);
    initializeUserRoutes(sammy);
    initializeContractRoutes(sammy);
    //initializePackageRoutes(sammy);
    initializeLookupRoutes(sammy);
}

function initializeCusomerRoutes(sammy) {

    sammy.get('/Customers', function (context) {
        context.load('/Customers', { dataType: 'html' }).swap();
    });
    sammy.get('/Customers/Add', function(context) {
        context.load('/Customers/Add', { dataType: 'html' })
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
        return false; // Allow form submit
    });
    sammy.get('/Customers/:id', function (context) {
        context.load('/Customers/' + context.params.id, { dataType: 'html' })
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
        return false; // Allow form submit
    });
    
}

function initializeClientRoutes(sammy) {

    sammy.get('/Clients', function (context) {
        context.load('/Clients', { dataType: 'html' }).swap();
    });
    sammy.get('/Clients/Add', function (context) {
        context.load('/Clients/Add', { dataType: 'html' })
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
        return false; // Allow form submit
    });
    sammy.get('/Clients/:id', function (context) {
        context.load('/Clients/' + context.params.id, { dataType: 'html' })
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
        return false; // Allow form submit
    });
}

function initializeUserRoutes(sammy) {
    
    sammy.get('/Users', function (context) {
        context.load('/Users', { dataType: 'html' }).swap();
    });
    sammy.get('/Users/Add', function (context) {
        context.load('/Users/Add', { dataType: 'html' })
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
        return false; // Allow form submit
    });
    sammy.get('/Users/:id', function (context) {
        context.load('/Users/' + context.params.id, { dataType: 'html' })
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
        return false; // Allow form submit
    });
}

function initializeContractRoutes(sammy) {

    sammy.get('/Contracts', function (context) {
        context.load('/Contracts', { dataType: 'html' }).swap();
    });
    sammy.get('/Contracts/Add', function (context) {
        context.load('/Contracts/Add', { dataType: 'html' })
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
        return false; // Allow form submit
    });
    sammy.get('/Contracts/:id', function (context) {
        context.load('/Contracts/' + context.params.id, { dataType: 'html' })
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
        return false; // Allow form submit
    });
}
//function initializePackageRoutes(sammy) {

//    sammy.get('/Packages', function (context) {
//        context.load('/Packages', { dataType: 'html' }).swap();
//    });
//    sammy.get('/Packages/Add', function (context) {
//        context.load('/Packages/Add', { dataType: 'html' })
//            .swap()
//            .then(function () {
//                initializePlugins();
//            });
//    });
//    sammy.post('/Packages', function (context) {
//        context.load('/Packages', { dataType: 'html' })
//            .swap()
//            .then(function () {
//                context.redirect('/#/Packages');
//            });
//        return true; // Allow form submit
//    });
//    sammy.get('/Packages/:id', function (context) {
//        context.load('/Packages/' + context.params.id, { dataType: 'html' })
//            .swap()
//            .then(function () {
//                initializePlugins();
//            });
//    });
//    sammy.post('/Packages/:id', function (context) {
//        context.load('/Packages/' + context.params.id, { dataType: 'html' })
//            .swap()
//            .then(function () {
//                context.redirect('/#/Packages');
//            });
//        return true; // Allow form submit
//    });
//}

function initializeLookupRoutes(sammy) {
    sammy.get('/Lookups/:type', function (context) {
        context.load('/Lookups/' + context.params.type, { dataType: 'html' }).swap();
    });
    sammy.get('/Lookups/:type/:filter', function (context) {
        //context.load('/Lookups/' + context.params.type + '/' + , { dataType: 'html' }).swap();
    });
}

function initializePlugins() {
    $(".chosen-select").chosen({ width: "100%" });
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