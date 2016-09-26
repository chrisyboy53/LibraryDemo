angular.module('LibraryDemo').controller('AddBookCtrl',['$scope' ,'LibraryEndpoint', 
    function($scope, LibraryEndpoint){
        $scope.NewBook = newBook();

        function newBook() {
            return {
                Id: -1,
                Title: "",
                Author: "",
                PublishDate: new Date()
            };
        }

        $scope.Save = function() {
            LibraryEndpoint.Book.save($scope.NewBook).$promise.then(function(){
                $scope.BookCreated = true;
                $scope.NewBook = newBook();
            });
        };

}]);