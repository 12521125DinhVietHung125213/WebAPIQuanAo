var tkhoan = document.getElementById ('tk')
var mkhau = document.getElementById ('mk')
var login = document.getElementById ('login')

login.onclick = function (e) {
    
}
var app = angular.module('AppBanHang', []);
app.controller("LoginCtrl", function ($scope, $http) {
    $scope.listMenu;
	
    $scope.LoadLogin= function (tenTaikhoan , matKhau) {
        $http({
            method: 'Post',
            url: current_url + '/api/TaiKhoan/login',
            data: {tenTaikhoan:tenTaikhoan ,matKhau : matKhau
                }
        }).then(function (response) {  
            debugger
            $scope.listMenu = response.data;  
        });
    };

    login.onclick = function (e) {
        $scope.LoadLogin(tkhoan.value , mkhau.value)
        localStorage.setItem('taikhoan', $scope.listMenu)
        location.assign('./Allsanpham.html')
    }
	 
    
});