function initializeRoutes(sammy) {
    
    sammy.get('/', function () {
        this.$element().html('Welcome!');
    });
    
    initializeCusomerRoutes(sammy);
    initializeClientRoutes(sammy);
    initializeUserRoutes(sammy);
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
        context.load('/Customers', { dataType: 'html' })
            .swap()
            .then(function() {
                this.redirect('/#/Customers');
            });
        return true; // Allow form submit
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
        context.load('/Customers/' + context.params.id, { dataType: 'html' })
            .swap()
            .then(function() {
                this.redirect('/#/Customers');
            });
        return true; // Allow form submit
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
        context.load('/Clients', { dataType: 'html' })
            .swap()
            .then(function() {
                context.redirect('/#/Clients');
            });
        return true; // Allow form submit
    });
    sammy.get('/Clients/:id', function (context) {
        context.load('/Clients/' + context.params.id, { dataType: 'html' })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Clients/:id', function (context) {
        context.load('/Clients/' + context.params.id, { dataType: 'html' })
            .swap()
            .then(function() {
                context.redirect('/#/Clients');
            });
        return true; // Allow form submit
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
        context.load('/Users', { dataType: 'html' })
            .swap()
            .then(function () {
                context.redirect('/#/Users');
            });
        return true; // Allow form submit
    });
    sammy.get('/Users/:id', function (context) {
        context.load('/Users/' + context.params.id, { dataType: 'html' })
            .swap()
            .then(function() {
                initializePlugins();
            });
    });
    sammy.post('/Users/:id', function (context) {
        context.load('/Users/' + context.params.id, { dataType: 'html' })
            .swap()
            .then(function () {
                context.redirect('/#/Users');
            });
        return true; // Allow form submit
    });
}

function initializeLookupRoutes(sammy) {
    sammy.get('/Lookups/:type', function (context) {
        context.load('/Lookups/' + context.params.type, { dataType: 'html' }).swap();
    });
}

function initializePlugins() {
    $(".chosen-select").chosen();
}