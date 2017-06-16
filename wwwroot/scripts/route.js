/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />
angular.module('LibraryDemo').config(['$routeProvider', function ($routeProvider) {
        var addBookRoute = {
            templateUrl: '/templates/AddBook.html',
            controller: 'AddBookCtrl'
        };
        var defaultRoute = {
            templateUrl: '/templates/index.html',
            controller: 'HomeCtrl'
        };
        $routeProvider.when('/AddBook', addBookRoute)
            .otherwise(defaultRoute);
    }]);
//# sourceMappingURL=route.js.map