/// <reference path="../../typings/angularjs/angular.d.ts" />
/// <reference path="../../typings/angularjs/angular-route.d.ts" />

angular.module('LibraryDemo').config(['$routeProvider', ($routeProvider:angular.route.IRouteProvider) => {
    var addBookRoute: angular.route.IRoute = {
        templateUrl: '/templates/AddBook.html',
        controller: 'AddBookCtrl'
    };
    var defaultRoute: angular.route.IRoute = {
        templateUrl: '/templates/index.html',
        controller: 'HomeCtrl'
    };
    
    $routeProvider.when('/AddBook', addBookRoute)
                    .otherwise(defaultRoute);
}]);