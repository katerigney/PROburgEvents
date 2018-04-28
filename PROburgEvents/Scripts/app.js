const eventsApp = angular.module("main", ["ngRoute"]);

eventsApp.config(function ($routeProvider) {

    $routeProvider.when("/events", {
        templateUrl: "/Scripts/app/views/allEvents.html",
        controller: "eventsContoller"
    })

    $routeProvider.when("/events/:eventID", {
        templateUrl: "/Scripts/app/views/eventProfile.html",
        controller: "eventProfileController"
    })

    $routeProvider.otherwise({ redirectTo: "/events" });
})

eventsApp.controller("eventProfileController", ["$scope", "$routeParams", "$http",
    function ($scope, $routeParams, $http) {
        $http({
            method: "GET",
            url: "/api/events/" + $routeParams.eventID
        }).then(resp => {
            $scope.event = resp.data;
        })
    }])

eventsApp.controller("eventsContoller", ["$scope", "$http", function ($scope, $http) {
    $http({
        method: "GET",
        url: "/api/events"
    }).then(resp => {
        $scope.events = resp.data
    })
}])
