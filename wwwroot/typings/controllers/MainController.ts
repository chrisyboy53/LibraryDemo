/// <reference path="../../../typings/angularjs/angular.d.ts" />

interface MainScope extends angular.IScope {
    IsPage: (page:string) => boolean;
}

angular.module('LibraryDemo').controller('MainCtrl',['$scope', '$location' , ($scope: MainScope, $location: angular.ILocationService) => {
    $scope.IsPage = (page) => {
        var current = $location.path().indexOf(page);
        if ($location.path() === '' && page === 'default') {
            return true;
        }
        return current > 0;
    };
}]);
