'use strict';
multiChannelToDoApp
    .controller('ToDoController', ['$scope', 'toDoService', function ($scope, toDoService) {

        $scope.get = function () {
            toDoService.getItems()
                .success(function (data) {
                    $scope.items = data;
            });
        };

        $scope.add = function () {
            toDoService.add($scope.itemText, $scope.itemPhone)
            .success(function(data){
                $scope.itemText = '';
                $scope.itemPhone = '';
                $scope.get();
            });
        };

        $scope.complete = function (item) {
            toDoService.complete(item)
                .success(function (data) {
                    $scope.get();
                });
        };

        $scope.get();

}]);