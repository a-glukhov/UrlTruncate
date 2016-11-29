var HistoryApp = angular.module('HistoryApp', []);
HistoryApp.controller('historyHandler', function ($scope, GetSrv) {
    function getAll() {
        $scope.loading = true;
        GetSrv.getAll()
            .success(function (links) {
                $scope.items = links;
                $scope.loading = false;
            })
            .error(function (error) {
                $scope.status = 'Error: ' + error.message;
            });
    }

    getAll();
});

HistoryApp.factory('GetSrv', ['$http', function ($http) {

    var GetSrv = {};
    GetSrv.getAll = function () {
        return $http.get('/Api/Link');
    };
    return GetSrv;

}]);
