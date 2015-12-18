(function($services) {
    'use strict';

    var webApi = function($$apiURL, $http)
    {
        var login = function(email, password)
        {
            var data = {
                grant_type: 'password',
                username: email,
                password: password
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
        }

        return
        {
            login: login
        };
    };


    $services.service('$webApi', webApi);

    webApi.$inject = ['$$apiUrl', '$http'];

})(globalScope.services);
