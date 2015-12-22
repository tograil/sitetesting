var globalScope = (function() {
    'use strict';

   angular.module('userManager',
        [
            'MyApp.services',
            'MyApp.controllers',
            'MyApp.directives',
            'ngRoute',
            'ngCookies',
            'ui.router'
        ]);

    var root = angular.module('userManager');//.constant('ApiUrl', 'http://localhost:53165');

    //root;

    angular.module('MyApp.directives', []);
    angular.module('MyApp.controllers', []);
    angular.module('MyApp.services', []);

    var directives = angular.module('MyApp.directives');
    var controllers = angular.module('MyApp.controllers').constant('ApiUrl', 'http://localhost:53165/');
    var services = angular.module('MyApp.services');

    //controllers.constant('$$ApiUrl', 'http://localhost:53165/');

    return {
        root: root,
        directives: directives,
        controllers: controllers,
        services: services
    };
})();

