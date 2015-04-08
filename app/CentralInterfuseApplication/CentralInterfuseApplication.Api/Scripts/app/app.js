(function ($) {
    
    Sammy('.content', function () {
        
        this.get('/', function (context) {
            //this.$element().html('Welcome!');
            context.load('/', { dataType: 'html', cache: false }).swap();
        });
        this.get('/login', function (context) {
            context.load('/login', { dataType: 'html', cache: false }).swap();
        });
        this.get('/logout', function (context) {
            context.load('/logout', { dataType: 'html', cache: false }).swap();
        });
        this.post('/login', function (context) {
            $(context.target).ajaxSubmit({
                success: function (data) {
                    //$.ajaxSetup({
                    //    headers: { 'Authorization': 'Token ' + data }
                    //});
                    //context.$element().html(data);
                    //document.domain = "lightstone.com";
                    //var store = new Sammy.Store({ type: 'cookie', domain: 'lightstone.com' });
                    //store.set('token', data);
                    $.removeCookie('token');
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