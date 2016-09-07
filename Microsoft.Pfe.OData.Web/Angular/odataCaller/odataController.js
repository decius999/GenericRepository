"use strict";

(function () {
    function odataController($http) {
        var vm = this;

        // ****************
        // Bindable Members
        // ****************
        vm.customers = undefined;
        vm.error = undefined;
        vm.input = undefined;

        // ****************
        // Bindable Function Declarations
        // ****************
        vm.filterCustomers = filterCustomers;

        // ****************
        // Bindable Function Implementations
        // ****************

        // ****************
        // Internals
        // ****************
        function filterCustomers(input) {
            if (input === '') {
                activate();
            }
            $http.get("/odata/Customers?$filter=substringof('" + input + "', LastName) or substringof('" + input + "', FirstName)")
                .then(onSucceed, onError);
        }

        function onSucceed(data) {
            vm.customers = data.data.value;
        }

        function onError(error) {
            vm.error = error;
        }

        function activate() {
            $http.get("/odata/Customers").then(onSucceed, onError);
        }

        activate();
    };

    app.controller("odataController", ["$http", odataController])
            .directive("odata", function () {
                return {
                    restrict: "E",
                    templateUrl: "/Angular/odataCaller/odata.html",
                    controller: "odataController as OData"
                };
            });
}());