angular.module('LibraryDemo').controller('HomeCtrl',
    [
        '$scope', 
        function($scope) {
            $scope.Books = [{ Id: 1, Title: 'Chrisyboy Book', Author: 'Chrisyboy' }];

    }]
);