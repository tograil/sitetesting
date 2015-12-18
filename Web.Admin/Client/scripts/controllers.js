(function($app, $controllers) {
    'use strict'

    $controllers.controller('MainApplication', ['$scope', '$http',
        function($scope, $http) {

        }]
    );

    $controllers.controller('ngLogin', ['$scope', '$http', '$location',
        function($scope, $http, $location) {
            // Erase the token when user logs out
            delete window.localStorage.token;

            $scope.login = { email: '', password: '' };
            $scope.loginSubmit = function () {

                var data = {
                    grant_type: 'password',
                    username: $scope.login.email,
                    password: $scope.login.password
                }

                $http({
                    method: 'POST',
                    url: 'http://localhost:53165/token/login',
                    transformRequest: function(obj) {
                        var str = [];
                        for(var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    data: data,
                    headers: {
                        'Accept': 'application/json',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }}).then(function(result) {
                    $location.path('/main');
                }, function(error) {
                    alert('error');
                });
            };
        }]
    );
})(globalScope, globalScope.controllers);