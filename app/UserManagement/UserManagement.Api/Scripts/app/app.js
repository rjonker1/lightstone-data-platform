(function ($) {

    var app = $.sammy('.content', function () {
        //this.use('Storage');
        //this.use(Sammy.Mustache);
        //this.use(Sammy.Storage);
        
        initializeRoutes(this);
    });

    $(function () {
        //var store = new Sammy.Store({ name: 'mystore', element: '.content', type: 'local' });
        //var token = store.get('token');

        //$.ajaxSetup({
        //    headers: { 'Authorization': 'Token ' + token }
        //});
        
        app.debug = true;
        app.raise_errors = true;
        app.run('#/');
    });

})(jQuery);