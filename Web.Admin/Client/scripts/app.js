globalScope = (function() {
    'use strict';

    var root = angular.module('userManager',
        [
            'MyApp.services',
            'MyApp.controllers',
            'MyApp.directives',
            'ngRoute',
            'ngCookies',
            'ui.router'
        ]).constant('$$apiURL', 'http://localhost:53165');

    var directives = angular.module('MyApp.directives', []);
    var controllers = angular.module('MyApp.controllers', []);
    var services = angular.module('MyApp.services', []);

    return {
        root: root,
        directives: directives,
        controllers: controllers,
        services: services
    };
})();

