/// <reference path="../../../typings/angularjs/angular.d.ts" />
/// <reference path="../../../typings/angularjs/angular-resource.d.ts" />

interface IBook extends angular.resource.IResource<IBook> {
    id: number;
    title: string;
    author: string;
    publishDate: Date;
}

interface ILibraryEndpoint extends angular.resource.IResourceClass<IBook> {
}

angular.module('LibraryDemo').factory('LibraryEndpoint', ( $resource:angular.resource.IResourceService ) => {

    var queryDescriptor: angular.resource.IActionDescriptor;
    queryDescriptor = {
        method: 'GET',
        isArray: true
    };

    var saveDescriptor: angular.resource.IActionDescriptor;
    saveDescriptor = {
        method: 'POST'
    }

    var obj: ILibraryEndpoint = $resource<IBook, ILibraryEndpoint>('/api/Book', null, {
        query: queryDescriptor,
        save: saveDescriptor
    });

    return obj;

});