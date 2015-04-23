'use strict';
var apiPath = "http://mobilehol-code.azurewebsites.net/tables";
multiChannelToDoApp
    .factory('toDoService', ['$http', function ($http) {
        return {

            getItems: function () {
                return $http.get(apiPath + '/TodoItem');
            },

            add: function (id, task) {
                return $http.post(apiPath + '/TodoItem', { "id": id + 1, "text": task, "complete": false });
            },

            complete: function (item) {
                return $http.patch(apiPath + '/TodoItem/' + item.Id, { "id": item.Id, "text": item.Text, "complete": true });
            }
        }
    }]);