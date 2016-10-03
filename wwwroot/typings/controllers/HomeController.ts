/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../RESTFul/Library.ts" />

interface HomeScope extends angular.IScope {
    Init : Function;
    Books : IBook[];
}

app.controller('HomeCtrl',['$scope', 
        'LibraryEndpoint',
        ($scope:HomeScope, LibraryEndpoint: ILibraryEndpoint) => {
            
            $scope.Init = () => {
                LibraryEndpoint.query((data) => {
                    $scope.Books = data;
                });
            }

        }]);