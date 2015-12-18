(function($app) {
    'use strict'

    $app.root.config(['$routeProvider',
        function($routeProvider)
        {
            $routeProvider.
                when('/main',{
                    templateUrl: 'views/main.html',
                    controller: 'MainApplication'
                })
                .when('/login', {
                    templateUrl: 'views/login.html',
                    controller: 'ngLogin'
                }).
            otherwise({
                redirectTo: '/login'
            });
        }]);
})(globalScope);
