var app = angular.module('AppQuanTri', []);
app.controller("CtrlTaiKhoan", function ($scope, $http) {

    $scope.btntexttk = "Thêm sản phẩm"
    $scope.insertTkhoan = function() { 
        $scope.btntexttk = "Đang thêm..."
        $http({
            method : 'POST',
            url : current_url  + 'api/TaiKhoan/create-taikhoan' ,
            data : $scope.tk
        })
        .then(function () {  
                alert('Thêm thành công sản phẩm...!')
                $scope.btntexttk = "Thêm sản phẩm"
                $scope.LoadAccount(); 
        }).error(function (){
            alert('Thêm thất bại ... !')
        });
     
    };




    $scope.listAccount;
    $scope.LoadAccount= function () {
        $http({
            method: 'GET',
            url: current_url + 'api/TaiKhoan/taikhoan-getall',
        }).then(function (response) {  
            debugger
            $scope.listAccount = response.data;  
        });
        
    }
    $scope.LoadAccount();

    $scope.GetbyIDTK = function (idtk){
        $http({
            method : 'GET',
            url : current_url + 'api/TaiKhoan/get-by-id/' +idtk,

        }).then (function(response){
            debugger;
            
            $scope.listAccount= [response.data];
        })
    };


    $scope.btnupdatetk = "Cập nhật sản phẩm"
    $scope.UpdateTk  = function (){

        $scope.tk.maTaiKhoan = document.querySelector('#matk').value
        $scope.tk.loaiTaiKhoan = document.querySelector('#maloaitk').value
        $scope.tk.tenTaiKhoan = document.querySelector('#tentaikhoan').value
        $scope.tk.matKhau = document.querySelector('#mk').value
        $scope.tk.sdt = document.querySelector('#sdt').value
        $scope.tk.email = document.querySelector('#Email').value
        $http({
            method : 'PUT',
            url : current_url  + 'api/TaiKhoan/update-taikhoan' ,
            data : $scope.tk
            
        }).then(function () {  
            alert('Sửa thành công sản phẩm...!')
            $scope.btnupdatetk = "Cập nhật sản phẩm" 
            $scope.LoadAccount();
            })

    };

    $scope.DeleteTK = function(maTaiKhoan){
        $http({
            method: 'Delete',
            url: current_url + 'api/TaiKhoan/Delete-taikhoan?MaKhachHang=' + maTaiKhoan,
            datatype : "json",
            data : JSON.stringify(maTaiKhoan)
        }).then (function(response){
            alert('Xóa sản phẩm');
            $scope.LoadAccount();
        })
        


    }

    var idsp = document.getElementById ('getbyidtk')

    var btnSearch = document.querySelector('button.btn-search')
    btnSearch.onclick = ()=> {
        console.log(idtk.value);
      $scope.GetbyIDTK(idtk.value)
    }
});