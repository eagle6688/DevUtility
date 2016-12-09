angular.module('app', []).controller('mainController', function ($scope) {
    $scope.submit = function () {
        if ($scope.mainForm.$valid) {
            alert('valid!');
        }
        else {
            alert('invalid!');
        }
    };
});