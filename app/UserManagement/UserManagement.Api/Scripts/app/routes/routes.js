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

    sammy.get('#/Customers', function (context) {
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
            success: function (data) {
                context.$element().html(data);
                initializePlugins();

                if (data.indexOf('Validation') < 0) { context.redirect('#/Customers'); }
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
    sammy.put('/Customers/:id', function (context) {
        var method = $(context.target).attr('method');
        $(context.target).ajaxSubmit({
            type: method,
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Customers'); }
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
            datatype: 'json',
            success: function (data) {

                //$('#table').bootstrapTable('refresh', { silent: true });
                context.redirect('#/Customers');
            }
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
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Clients'); }
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
    sammy.put('/Clients/:id', function (context) {
        var method = $(context.target).attr('method');
        $(context.target).ajaxSubmit({
            type: method,
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Clients'); }
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
            datatype: 'json',
            success: function (data) {

                //$('#table').bootstrapTable('refresh', { silent: true });
                context.redirect('#/Clients');
            }
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
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Users'); }
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
    sammy.put('/Users/:id', function (context) {
        var method = $(context.target).attr('method');
        $(context.target).ajaxSubmit({
            type: method,
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Users'); }
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
            datatype: 'json',
            success: function(data) {
                
                //$('#table').bootstrapTable('refresh', { silent: true });
                context.redirect('#/Users');
            }
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
            success: function (data) {
                context.$element().html(data);+
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Contracts'); }
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
    sammy.put('/Contracts/:id', function (context) {
        var method = $(context.target).attr('method');
        $(context.target).ajaxSubmit({
            type: method,
            success: function (data) {
                context.$element().html(data);
                initializePlugins();
                if (data.indexOf('Validation') < 0) { context.redirect('#/Contracts'); }
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
            datatype: 'json',
            success: function (data) {

                //$('#table').bootstrapTable('refresh', { silent: true });
                context.redirect('#/Contracts');
            }
        });
    });
}

function initializeLookupRoutes(sammy) {
    sammy.get('/ValueEntities/:type', function (context) {
        context.load('/ValueEntities/' + context.params.type, { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/ValueEntities/Add/:type', function (context) {
        context.load('/ValueEntities/Add/' + context.params.type, { dataType: 'html', cache: false })
            .swap()
            .then(function () {
                initializePlugins();
            });
    });
    sammy.post('/ValueEntities', function (context) {
        $(context.target).ajaxSubmit({
            success: function (response) {
                if (data.indexOf('Validation') < 0) { context.redirect('#/ValueEntities/' + response); }
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false;
    });
    sammy.put('/ValueEntities/:id', function (context) {
        var method = $(context.target).attr('method');
        $(context.target).ajaxSubmit({
            type: method,
            success: function (response) {
                if (data.indexOf('Validation') < 0) { context.redirect('#/ValueEntities/' + response); }
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false;
    });
    sammy.get('/ValueEntities/:type/:filter', function (context) {
        //context.load('/Lookups/' + context.params.type + '/' + , { dataType: 'html', cache: false }).swap();
    });
    sammy.get('/ValueEntities/Delete/:id', function (context) {
        $.ajax({
            type: "DELETE",
            url: '/ValueEntities/' + context.params.id,
            contentType: 'application/json',
            datatype: 'json'
        });
    });
}

function initializePlugins() {
    $(".chosen-select").chosen({ width: "100%" });
    $('.input-group.date').bootstrapdatepicker({ autoclose: true, format: "yyyy-mm-dd" });
    UserManagement.panelBodyCollapse();
    
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
            if ($('#' + ui.item.value).length) {
                return;
            }

            var $container = $(this).closest('.entity-autocomplete');
            var $select = $container.find('select');
            $select.append('<option id="' + ui.item.value + '" selected="true" value="' + ui.item.value + '">' + ui.item.label + '</option>');
            $select.trigger("chosen:updated");
        }
    });
    
    //$('.packag-autocomplete .chosen-choices input').autocomplete({
    //    source: function (request, response) {
    //        var $container = $(this.element).closest('.packag-autocomplete');
    //        var type = $container.data('type');
    //        $.ajax({
    //            url: "/packages/" + request.term + "/",
    //            dataType: "json",
    //            beforeSend: function () { $('ul.chosen-results').empty(); },
    //            success: function (data) {
    //                response($.map(data, function (item) {
    //                    return {
    //                        label: item.name,
    //                        value: item.packageId
    //                    };
    //                }));
    //            }
    //        });
    //    },
    //    select: function (event, ui) {
    //        if ($('#' + ui.item.value).length) {
    //            return;
    //        }
    //        var $container = $(this).closest('.packag-autocomplete');
    //        var $select = $container.find('select');
    //        $select.append('<option id="' + ui.item.value + '" selected="true" value="' + ui.item.value + '|' + ui.item.label + '">' + ui.item.label + '</option>');
    //        $select.trigger("chosen:updated");
    //    }
    //});
    
    //$('.acc-owner .chosen-search input').autocomplete({
    //    source: function (request, response) {
    //        //var $container = $(this.element).closest('.packag-autocomplete');
    //        //var type = $container.data('type');
    //        $.ajax({
    //            url: "/users/" + request.term + "/",
    //            dataType: "json",
    //            beforeSend: function () { $('ul.chosen-results').empty(); },
    //            success: function (data) {
    //                response($.map(data, function (item) {
    //                    return {
    //                        label: item.name,
    //                        value: item.packageId
    //                    };
    //                }));
    //            }
    //        });
    //    },
    //    select: function (event, ui) {
    //        if ($('#' + ui.item.value).length) {
    //            return;
    //        }
    //        var $container = $(this).closest('.packag-autocomplete');
    //        var $select = $container.find('select');
    //        $select.append('<option id="' + ui.item.value + '" selected="true" value="' + ui.item.value + '|' + ui.item.label + '">' + ui.item.label + '</option>');
    //        $select.trigger("chosen:updated");
    //    }
    //});

    $('#AccountOwnerId').ajaxComboBox(
        "/users/",
        {
            lang: 'en',
            bind_to: 'select',
            primary_key: 'packageId',
            per_page: 10,
        }
    );
    //.bind('select', function () {
    //    var val = $(this).val();
    //    var id = $('#PackageIdNames_primary_key').val();

    //    if ($('#' + id).length) {
    //        return;
    //    }

    //    var $container = $(this).closest('.packag-autocomplete');
    //    var $select = $container.find('select');
    //    $select.append('<option id="' + id + '" selected="true" value="' + id + '|' + val + '">' + val + '</option>');
    //    $select.trigger("chosen:updated");
    //});

    $('.packag-autocomplete .chosen-choices input').attr("name", "PackageIdNames");
    $('.packag-autocomplete .chosen-choices input').ajaxComboBox(
        "/packages/",
        {
            lang: 'en',
            bind_to: 'select',
            primary_key: 'packageId',
            per_page: 10,
        }
    )
    .bind('select', function () {
        var val = $(this).val();
        var id = $('#PackageIdNames_primary_key').val();
        
        if ($('#' + id).length) {
            return;
        }
        
        var $container = $(this).closest('.packag-autocomplete');
        var $select = $container.find('select');
        $select.append('<option id="' + id + '" selected="true" value="' + id + '|' + val + '">' + val + '</option>');
        $select.trigger("chosen:updated");
    });

    $(".list-group-item a.close-box").click(function () {

        removeListItem(this);
    });

    function removeListItem(element) {

        $(element).parent().parent().remove();
    }

    $('#ClientIds').autocomplete({
        source: function(request, response) {
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

            if ($('#' + ui.item.value).length) {
                return;
            }

            console.log(ui.item.value);

            var $container = $(this).closest('div');
            var $listGroup = $container.find('.list-group');
            
            var $item = $("<div>", { "class": "list-group-item" }).appendTo($listGroup);

            var $left = $("<div>", { "class": "pull-left" }).appendTo($item);
            var $remove = $("<a>", { "class": "btn btn-danger btn-xs close-box" }).appendTo($left);
            var $removeIcon = $("<i>", { "class": "fa fa-times" }).appendTo($remove);
            
            var index = $listGroup.children('li').length;
            
            var $id = $("<input>", {
                id: ui.item.value,
                name: "ClientId[" + index + "]",
                value: ui.item.value,
                type: 'hidden'
            }).appendTo($item);

            $remove.click(function() {
                removeListItem(this);
            });
            
            var $label = $("<label>", { text: ui.item.label }).appendTo($item);
            
            var $value = $("<input>", {
                name: "UserAlias[" + index + "]",
                value: "",
                "class": "form-control"
            }).appendTo($item);
        },
        close: function(event, ui) {
            $(this).val('');
        }
    });
}