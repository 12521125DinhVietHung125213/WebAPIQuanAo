var app = angular.module ('AppQuanTri',[]);

app.controller ('CtrlSanPham',function ($scope , $http){
    $scope.btntext = "Thêm sản phẩm"
    $scope.insertData = function() { 
        $scope.btntext = "Đang thêm..."
        $http({
            method : 'POST',
            url : current_url  + 'api/SanPham/create-SanPham' ,
            data : $scope.Sp
        })
        .then(function () {  
                alert('Thêm thành công sản phẩm...!')
                $scope.btntext = "Thêm sản phẩm"
                $scope.GetallSP(); 
                // $scope.reSestForm();
        }).error(function (){
            alert('Thêm thất bại ... !')
        });
     
    };

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


    $scope.btntextud = "Cập nhật sản phẩm"
    $scope.updateSP  = function (){

        $scope.Sp.maSanPham = document.querySelector('#masp').value
        $scope.Sp.maDanhMuc = document.querySelector('#loaisp').value
        $scope.Sp.tenSanPham = document.querySelector('#tensp').value
        $scope.Sp.soLuong = document.querySelector('#soluong').value
        $scope.Sp.gia = document.querySelector('#gia').value
        $scope.Sp.size = document.querySelector('#size').value
        $scope.Sp.mauSac = document.querySelector('#color').value
        $http({
            method : 'PUT',
            url : current_url  + 'api/SanPham/update-SanPham' ,
            data : $scope.Sp
            
        }).then(function () {  
            alert('Sửa thành công sản phẩm...!')
            $scope.btntextud = "Cập nhật sản phẩm" 
            $scope.GetallSP();
            })

    };


    $scope.DeleteSP = function(maSanPham){
        $http({
            method: 'Delete',
            url: current_url + 'api/SanPham/Delete-SanPham?MaSanPham=' + maSanPham,
            datatype : "json",
            data : JSON.stringify(maSanPham)
        }).then (function(response){
            alert('Xóa sản phẩm');
            $scope.GetallSP();
            
        })
        


    }

});


   

  