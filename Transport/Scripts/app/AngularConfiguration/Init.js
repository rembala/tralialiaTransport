(function (app) {
    'use strict';

    app.controller('rootCtrl', rootCtrl);

    rootCtrl.$inject = ['$scope'];

    function rootCtrl($scope) {

        $scope.test = "labas";
    }

})(angular.module('core'));
