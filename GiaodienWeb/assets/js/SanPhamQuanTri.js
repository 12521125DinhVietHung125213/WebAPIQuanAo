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
                resetInputValues();
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


    $scope.GetbyIDSP = function (idsp){
        $http({
            method : 'GET',
            url : current_url + 'api/SanPham/get-by-id/' +idsp,

        }).then (function(response){
            debugger;
            
            $scope.SPlist= [response.data];
        })
    };


    $scope.GetbyIDSP = function (idsp){
        $http({
            method : 'GET',
            url : current_url + 'api/SanPham/get-by-id/' +idsp,

        }).then (function(response){
            debugger;
            
            $scope.SPlist= [response.data];
        })
    };


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
            resetInputValues();
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
    };

    // function resetInputValues() {
    //     // Lấy tất cả các thẻ input trên trang
    //     var inputElements = document.querySelectorAll('input');
      
    //     // Duyệt qua từng thẻ input và đặt giá trị về rỗng, trừ những thẻ có class "exclude-reset"
    //     inputElements.forEach(function (input) {
    //       // Kiểm tra xem thẻ input có class "exclude-reset" không
    //       if (!input.classList.contains('add-product') || !input.classList.contains('update-product') ) {
    //         // Nếu không có class "exclude-reset", đặt giá trị về rỗng
    //         input.value = '';
    //       }
    //       // Nếu có class "exclude-reset", bỏ qua thẻ này
    //     });
    //   }

      
      var idsp = document.getElementById ('getbyidsp')

      var btnSearch = document.querySelector('button.btn-search')
      btnSearch.onclick = ()=> {
          console.log(idsp.value);
        $scope.GetbyIDSP(idsp.value)
      }

});


   

  