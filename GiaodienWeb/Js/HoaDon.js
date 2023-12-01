var app = angular.module ('AppQuanTri',[]);
app.controller ('CtrlHoaDon',function ($scope , $http){
    // $scope.btntext = "Thêm sản phẩm"
    // $scope.insertData = function() { 
    //     $scope.btntext = "Đang thêm..."
    //     $http({
    //         method : 'POST',
    //         url : current_url  + 'api/SanPham/create-SanPham' ,
    //         data : $scope.Sp
    //     })
    //     .then(function () {  
    //             alert('Thêm thành công sản phẩm...!')
    //             $scope.btntext = "Thêm sản phẩm"
    //             $scope.GetallSP(); 
    //             resetInputValues();
    //             // $scope.reSestForm();
    //     }).error(function (){
    //         alert('Thêm thất bại ... !')
    //     });
        
     
    // };

    $scope.Hoadonlist ;
    $scope.GetallHD = function (){
        $http({
            method : 'GET',
            url : current_url + 'api/HoaDon/get-all'
        }).then (function(response){
            $scope.Hoadonlist = response.data;
        })
    };
    $scope.GetallHD();


    
});


   

  