angular.module('LibraryDemo').controller('MainCtrl',['$scope', '$location' , function($scope, $location) {

    $scope.IsPage = function(page) {
        var current = $location.path().indexOf(page);
        if($location.path() === "" && page === "default") {
            return true;
        }
        return current > 0;
    };

}]);