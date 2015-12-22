(function($services) {

'use strict';

    

    var webApi = function ($http, $q, ApiUrl) {

        //var ApiUrl = 'http://localhost:53165';

        var loginSuccess = function (response, deffer) {
            deffer.resolve(response);
        };

        var loginError = function (response, deffer) {
            deffer.reject(response);
        };

        var login = function(email, password) {
            var deffer = $q.defer();

            var data = {
                grant_type: 'password',
                username: email,
                password: password
            }

            $http({
                method: 'POST',
                url: ApiUrl + 'token/login',
                transformRequest: function(obj) {
                    var str = [];
                    for (var p in obj)
                        if (obj.hasOwnProperty(p))str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    return str.join("&");
                },
                data: data,
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            }).then(function(result) {

                loginSuccess(result, deffer);
            }, function(error) {
                loginError(error, deffer);
            });

            return deffer.promise;
        };
        
        return {
            loginUser: login
        };
    };

    webApi.$inject = ['$http', '$q', 'ApiUrl'];

    $services.service('webApi', webApi);

})(globalScope.controllers);

