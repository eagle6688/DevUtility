angular.module('app', []).controller('mainController', function ($scope) {
    $scope.hello = function (name) {
        alert('Hello ' + (name || 'world') + '!');
    };
});