(function ($) {

    var app = $.sammy('.content', function () {

        initializeRoutes(this);

        this.get('/logout', function (context) {
            $.removeCookie('token', { domain: 'lightstone.co.za' });
            context.load("/");
            //context.load('/logout', { dataType: 'html', cache: false }).swap();
        });
    });

    $(function () {
        app.debug = true;
        app.raise_errors = true;
        app.run('#/');
    });

})(jQuery);