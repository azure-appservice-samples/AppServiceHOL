'use strict';
var apiPath = "http://mobilehol-code.azurewebsites.net/tables";
multiChannelToDoApp
    .factory('toDoService', ['$http', function ($http) {
        return {

            getItems: function () {
                return $http.get(apiPath + '/TodoItem');
            },

            add: function (task, phoneNumber) {
                return $http.post(apiPath + '/TodoItem', { "text": task, "phoneNumber": phoneNumber, "complete": false });
            },

            complete: function (item) {
                return $http.patch(apiPath + '/TodoItem/' + item.id, { "id": item.id, "text": item.text, "complete": true });
            }
        }
    }]);