/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../RESTFul/Library.ts" />
app.controller('HomeCtrl', ['$scope',
    'LibraryEndpoint',
    function ($scope, LibraryEndpoint) {
        $scope.Init = function () {
            LibraryEndpoint.query(function (data) {
                $scope.Books = data;
            });
        };
    }]);
//# sourceMappingURL=HomeController.js.map