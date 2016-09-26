angular.module('LibraryDemo').factory("LibraryEndpoint", function($resource){
    return { 
        Book: $resource("/api/Book", {}, { 
            query: { method: "GET", isArray:true },
            save: { method: "POST" }
            }),

    };
});