angular.module('LibraryDemo').controller('AddBookCtrl',['$scope' ,'LibraryEndpoint', '$timeout',
    function($scope, LibraryEndpoint, $timeout){
        $scope.NewBook = newBook();

        function newBook() {
            return {
                Id: 0,
                Title: "",
                Author: "",
                PublishDate: new Date()
            };
        }

        $scope.Save = function() {
            LibraryEndpoint.Book.save($scope.NewBook).$promise.then(function() {
                $scope.BookCreated = true;
                $scope.OldBook = $scope.NewBook;

                $timeout(function() { 
                        $scope.BookCreated = false; 
                    },
                    1000 * 10
                );

                $scope.NewBook = newBook();
            });
        };

}]);