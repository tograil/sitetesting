(function($app, $controllers) {
    'use strict';

    $controllers.controller('MainApplication', ['$scope', '$http',
        function($scope, $http) {

        }]
    );

    $controllers.controller('ngLogin', ['$scope', '$http', '$location', 'webApi',
        function($scope, $http, $location, webApi) {
            // Erase the token when user logs out
            delete window.localStorage.token;

            $scope.login = { email: '', password: '' };
            $scope.loginSubmit = function () {
                webApi.loginUser($scope.login.email, $scope.login.password).then(
                    function(result) {
                        $location.path('/main');
                    },
                    function(result)
                    {
                        alert('error');
                    }
                );

            };
        }]
    );
})(globalScope, globalScope.controllers);