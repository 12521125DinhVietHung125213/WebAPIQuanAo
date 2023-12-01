var app = angular.module ('AppQuanTri',[]);
app.controller ('CtrlSanPham',function ($scope , $http){
   

    $scope.SPlist ;
    $scope.GetallSP = function (){
        $http({
            method : 'GET',
            url : current_url + 'api/SanPham/get-all'
        }).then (function(response){
            $scope.SPlist = response.data;
        })
    };
    $scope.GetallSP();


    $scope.SPlistTop ;
    $scope.GetallSP = function (){
        $http({
            method : 'GET',
            url : current_url + 'api/SanPham/get-TopSpBanChay'
        }).then (function(response){
            $scope.SPlistTop = response.data;
        })
    };
    $scope.GetallSP();


   
    
});


   

  