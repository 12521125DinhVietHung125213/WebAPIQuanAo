var app = angular.module('AppQuanTri', []);
app.controller("KhachCtrl", function ($scope, $http) {
    $scope.listMenu;
	
    $scope.LoadMenu= function () {
        $http({
            method: 'GET',
            url: current_url + '/api/Khach/get-all',
        }).then(function (response) {  
            debugger
            $scope.listMenu = response.data;  
        });
        
    }
    $scope.LoadMenu()


});
