/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../../../typings/angularjs/angular-resource.d.ts" />
angular.module('LibraryDemo').factory('LibraryEndpoint', function ($resource) {
    var queryDescriptor;
    queryDescriptor = {
        method: 'GET',
        isArray: true
    };
    var saveDescriptor;
    saveDescriptor = {
        method: 'POST'
    };
    var obj = $resource('/api/Book', null, {
        query: queryDescriptor,
        save: saveDescriptor
    });
    return obj;
});
//# sourceMappingURL=Library.js.map