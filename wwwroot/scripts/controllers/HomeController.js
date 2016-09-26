angular.module('LibraryDemo').controller('HomeCtrl',
    [
        '$scope', 
        'LibraryEndpoint',
        function($scope, LibraryEndpoint) {

            $scope.Init = function() {
                LibraryEndpoint.Book.query(function(data) {
                    $scope.Books = data;
                })
            };
            
    }]
);