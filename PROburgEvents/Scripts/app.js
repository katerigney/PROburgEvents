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
        console.log($routeParams);
        $http({
            method: "GET",
            url: "/api/events/" + $routeParams.eventID
        }).then(resp => {
            console.log(resp);
            $scope.event = resp.data;
        })
    }])

eventsApp.controller("eventsContoller", ["$scope", "$http", function ($scope, $http) {

    

    const getEvents = () => {
        let searchURL = "/api/events";
        if ($scope.searchQuery) {
            searchURL = searchURL + "?title=" + $scope.searchQuery
        }
        $http({
            method: "GET",
            url: searchURL
        }).then(resp => {
            console.log(resp.data);
            $scope.events = resp.data;
        })
    }

    $scope.searchForEvent = () => {
        getEvents();
    }  

    $scope.addAttendee = (event) => {
        console.log("button was clicked");
        $http({
            method: "PUT",
            url: "/api/events/" + eventID + "/AddAttendee/",
            data: {
                Email: $scope.attendeeEmail
            }
        }).then(resp => {
            console.log(resp.data);
            $scope.respMessage = resp.data;
        })
    }

    var start = () => {
        $scope.pageTitle = "PROburg Events Page"
        getEvents();
    }

    start();
}])
