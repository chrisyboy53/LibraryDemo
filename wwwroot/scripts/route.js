angular.module('LibraryDemo').config(['$routeProvider',function($routeProvider){

    $routeProvider.when('/AddBook', {
        templateUrl: '/templates/AddBook.html',
        controller: 'AddBookCtrl'
    })
    .otherwise({
        templateUrl: '/templates/index.html',
        controller: 'HomeCtrl'
    });

}]);