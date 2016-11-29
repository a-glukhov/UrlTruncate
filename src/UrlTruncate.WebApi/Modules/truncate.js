var TruncateApp = angular.module('TruncateApp', []);
TruncateApp.controller('truncateHandler', function ($scope, PostSrv) {
    function postLink() {
        PostSrv.postLink($scope.originalUrl)
            .success(function(link) {
                $scope.truncatedUrl = link;
            })
            .error(function(error) {
                $scope.status = 'Error: ' + error.message;
                alert('Error, ' + $scope.status);
            });
    }

    $scope.truncateLink = function() {
        postLink();
    }
});

TruncateApp.factory('PostSrv', [
    '$http', function($http) {

        var PostSrv = {};
        PostSrv.postLink = function ($originalUrl) {
            return $http.post('/Api/Link', '"' + $originalUrl + '"');
        };
        return PostSrv;
    }
]);