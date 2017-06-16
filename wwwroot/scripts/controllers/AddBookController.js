/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="../RESTFul/Library.ts" />
angular.module('LibraryDemo').controller('AddBookCtrl', ['$scope', 'LibraryEndpoint', '$timeout',
    function ($scope, LibraryEndpoint, $timeout) {
        var defaultBook = function () {
            var tmpBook = {};
            tmpBook.id = 0;
            tmpBook.title = '';
            tmpBook.author = '';
            tmpBook.publishDate = new Date();
            return tmpBook;
        };
        $scope.NewBook = defaultBook();
        $scope.Save = function () {
            LibraryEndpoint.save($scope.NewBook).$promise.then(function () {
                $scope.BookCreated = true;
                $scope.OldBook = $scope.NewBook;
                $timeout(function () {
                    $scope.BookCreated = false;
                }, 1000 * 10);
                $scope.NewBook = defaultBook();
            });
        };
    }]);
//# sourceMappingURL=AddBookController.js.map