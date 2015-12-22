(function($app) {
    'use strict';

    $app.root.config(['$routeProvider',
        function($routeProvider)
        {
            $routeProvider.
                when('/main',{
                    templateUrl: 'client/views/main.html',
                    controller: 'MainApplication'
                })
                .when('/login', {
                    templateUrl: 'client/views/login.html',
                    controller: 'ngLogin'
                }).
            otherwise({
                redirectTo: '/login'
            });
        }]);
})(globalScope);
