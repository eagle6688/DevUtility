angular.module('app', []).controller('mainController', function ($scope) {
    $scope.colors = [
      { name: 'black', shade: 'dark' },
      { name: 'white', shade: 'light', notAnOption: true },
      { name: 'red', shade: 'dark' },
      { name: 'blue', shade: 'dark', notAnOption: true },
      { name: 'yellow', shade: 'light', notAnOption: false }
    ];

    $scope.myColor = $scope.colors[2];
});