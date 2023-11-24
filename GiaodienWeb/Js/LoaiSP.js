var app = angular.module('AppQuanTri', []);
app.controller("LoaiSPCtrl", function ($scope, $http) {
    $scope.listMenu;
	
    $scope.LoadMenu= function () {
        $http({
            method: 'GET',
            url: current_url + '/api/DanhMuc/get-all',
        }).then(function (response) {  
            
            $scope.listMenu = response.data;  
        });
        
    }
    $scope.LoadMenu()


});