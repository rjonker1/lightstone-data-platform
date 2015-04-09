function initializeRoutes(sammy) {
    
    initializeAuthRoutes(sammy);
}

function initializeAuthRoutes(sammy) {

    //sammy.get('#/login', function (context) {
    //    context.load('/login', { dataType: 'html', cache: false }).swap();
    //});
    //sammy.get('/logout', function (context) {
    //    context.load('/logout', { dataType: 'html', cache: false }).swap();
    //});
    sammy.post('/login', function (context) {
        $(context.target).ajaxSubmit({
            success: function (data) {
                context.$element().html(data);
            }
        });
        // !!! Important !!! 
        // always return false to prevent standard browser submit and page navigation
        return false; 
    });
}