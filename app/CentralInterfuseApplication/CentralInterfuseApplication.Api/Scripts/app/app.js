(function ($) {
    
    Sammy('.content', function () {
        
        this.get('/', function (context) {
            context.load('/', { dataType: 'html', cache: false }).swap();
        });
        this.get('/login', function (context) {
            context.load('/login', { dataType: 'html', cache: false }).swap();
        });
        this.get('/logout', function (context) {
            $.removeCookie('token', { domain: 'lightstone.com' });
            context.redirect("/");
            //context.load('/logout', { dataType: 'html', cache: false }).swap();
        });
        this.post('/login', function (context) {
            $(context.target).ajaxSubmit({
                success: function (data) {
                    $.cookie('token', data, { domain: 'lightstone.com' });
                    context.redirect("/");
                }
            });
            // !!! Important !!! 
            // always return false to prevent standard browser submit and page navigation
            return false;
        });
    }).run('#/');

})(jQuery);