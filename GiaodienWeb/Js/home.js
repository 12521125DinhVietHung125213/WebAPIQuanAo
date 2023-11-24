var app = angular.module('AppBanHang', []);
app.controller("HomeCtrl", function ($scope, $http) {
    $scope.listMenu;
	
    $scope.LoadMenu= function () {
        $http({
            method: 'GET',
            url: current_url + '/api/SanPham/get-all',
        }).then(function (response) {  
            
            $scope.listMenu = response.data;  
        });
        
    }
    $scope.LoadMenu()

    $scope.Addsp= function (data) {
        $http({
            method: 'POST',
            url: current_url + '/api/SanPham/create-SanPham',
            data: JSON.stringify(data)
        }).then(function (response) {  
            debugger
            $scope.listMenu = response.data;  
        });
        
    }
    $scope.sp = {}; 

    const data = {}
      

      $scope.submitForm = function() {
        $scope.Addsp($scope.sp)
      // Xử lý logic khi form được submit
      console.log('Form submitted with:', sp);
      debugger
    
    }


    // $scope.Deletesp= function () {
    //     $http({
    //         method: 'DELETE',
    //         url: current_url + 'SanPham/update-SanPham',
    //     }).then(function (response) {  
            
    //         $scope.listMenu = response.data;  
    //     });
        
    // }
    // $scope.Deletesp()
});

