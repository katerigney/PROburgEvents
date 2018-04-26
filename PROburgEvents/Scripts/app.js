const eventsApp = angular.module("main", ["ngRoute"]);

eventsApp.config(function ($routeProvider) {

    $routeProvider.when("/events", {
        templateUrl: "/Scripts/app/views/events.html",
        controller: "eventsContoller"
    })

    $routeProvider.when("/events/:eventID", {
        templateUrl: "/Scripts/app/views/eventProfile.html",
        controller: "eventProfileController"
    })

    $routeProvider.otherwise({ redirectTo: "/events" });
})
