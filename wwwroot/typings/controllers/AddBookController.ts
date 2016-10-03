/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../RESTFul/Library.ts" />

interface AddBookScope extends angular.IScope {
    NewBook: IBook;
    OldBook: IBook;
    Save: Function;
    BookCreated: boolean;
}

angular.module('LibraryDemo').controller('AddBookCtrl',['$scope' ,'LibraryEndpoint', '$timeout', 
    ($scope: AddBookScope, LibraryEndpoint: ILibraryEndpoint, $timeout:angular.ITimeoutService) => {
        var defaultBook = () => {
            var tmpBook:IBook = {} as IBook;
            tmpBook.id = 0;
            tmpBook.title = '';
            tmpBook.author = '';
            tmpBook.publishDate = new Date();
            return tmpBook;
        };
        
        
        $scope.NewBook = defaultBook();

        $scope.Save = () => {
            LibraryEndpoint.save($scope.NewBook).$promise.then(() => {
                $scope.BookCreated = true;
                $scope.OldBook = $scope.NewBook;

                $timeout(() => {
                    $scope.BookCreated = false;
                }, 1000 * 10);

                $scope.NewBook = defaultBook();
            });
        };
}]);
