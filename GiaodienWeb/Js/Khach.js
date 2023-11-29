var app = angular.module('AppQuanTri', []);
app.controller("KhachCtrl", function ($scope, $http) {
    $scope.btntextkh = "Thêm sản phẩm"
    $scope.addkhach = function() { 
        $scope.btntext = "Đang thêm..."
        $http({
            method : 'POST',
            url : current_url  + 'api/Khach/create-khach' ,
            data : $scope.khach
        })
        .then(function () {  
                alert('Thêm thành công sản phẩm...!')
                $scope.btntextkh = "Thêm sản phẩm"
                $scope.LoadKhach() ;
                // $scope.reSestForm();
        }).error(function (){
            alert('Thêm thất bại ... !')
        });
     
    };

    
    $scope.listKhach;
    $scope.LoadKhach= function () {
        $http({
            method: 'GET',
            url: current_url + 'api/Khach/get-all',
        }).then(function (response) {  
            debugger
            $scope.listKhach = response.data;  
        });
        
    }
    $scope.LoadKhach();
    
    $scope.btnudkh = "Cập nhật sản phẩm"
    $scope.updateKh  = function (){

        $scope.khach.maKhachHang = document.querySelector('#makh').value
        $scope.khach.tenKhachHang = document.querySelector('#tenkh').value
        $scope.khach.gioiTinh = document.querySelector('#gioiTinh').value
        $scope.khach.sdt = document.querySelector('#sdt').value
        $scope.khach.email = document.querySelector('#email').value
        $scope.khach.diaChi = document.querySelector('#diachi').value
        $http({
            method : 'PUT',
            url : current_url  + 'api/Khach/update-khach' ,
            data : $scope.khach
            
        }).then(function () {  
            alert('Sửa thành công sản phẩm...!')
            $scope.btnudkh = "Cập nhật sản phẩm" 
            $scope.LoadKhach();
            })

    };

    $scope.Deletekh = function(maKhachHang){
        $http({
            method: 'Delete',
            url: current_url + 'api/Khach/Delete-Khach?MaKhachHang=' + maKhachHang,
            datatype : "json",
            data : JSON.stringify(maKhachHang)
        }).then (function(response){
            alert('Xóa sản phẩm');
            $scope.LoadKhach();

        })
        


    }




});
