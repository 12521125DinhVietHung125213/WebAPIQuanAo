var app = angular.module('AppQuanTri', []);
app.controller("LoaiSPCtrl", function ($scope, $http) {

    $scope.btnlsp = "Thêm loại SP"
    $scope.addLSP = function() { 
        $scope.btnlsp = "Đang thêm..."
        $http({
            method : 'POST',
            url : current_url  + 'api/DanhMuc/create-DanhMuc' ,
            data : $scope.lsp
        })
        .then(function () {  
                alert('Thêm thành công sản phẩm...!')
                $scope.btnlsp = "Thêm" 
                $scope.LoadLoaiSP();

        }).error(function (){
            alert('Thêm thất bại ... !')
        });
     
    };

    $scope.listLoaiSP;	
    $scope.LoadLoaiSP= function () {
        $http({
            method: 'GET',
            url: current_url + 'api/DanhMuc/get-all',
        }).then(function (response) {  
            
            $scope.listLoaiSP = response.data;  
        });
        
    }
    $scope.LoadLoaiSP();

    $scope.btntextlspud = "Cập nhật sản phẩm"
    $scope.updateLSP  = function (){

        $scope.lsp.maDanhMuc = document.querySelector('#maDanhMuc').value
        $scope.lsp.danhMucCha = document.querySelector('#danhMucCha').value
        $scope.lsp.tenDanhMuc = document.querySelector('#tenDanhMuc').value
        $http({
            method : 'PUT',
            url : current_url  + 'api/DanhMuc/update-DanhMuc' ,
            data : $scope.lsp
            
        }).then(function () {  
            alert('Sửa thành công sản phẩm...!')
            $scope.btntextlspud = "Cập nhật sản phẩm" 
            $scope.LoadLoaiSP();
            })

    };

    $scope.DeleteLSP = function(maDanhMuc){
        $http({
            method: 'Delete',
            url: current_url + 'api/DanhMuc/Delete-DanhMuc?MaDanhMuc=' + maDanhMuc,
            datatype : "json",
            data : JSON.stringify(maDanhMuc)
        }).then (function(response){
            alert('Xóa sản phẩm');
            $scope.LoadLoaiSP();
        })
        


    }


});