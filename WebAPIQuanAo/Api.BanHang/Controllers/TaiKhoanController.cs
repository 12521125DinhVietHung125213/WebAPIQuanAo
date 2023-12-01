using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private ITaiKhoanBusiness _taiKhoanBusiness;
        public TaiKhoanController( ITaiKhoanBusiness taiKhoanBusiness)
        {
            _taiKhoanBusiness = taiKhoanBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _taiKhoanBusiness.Login(model.TenTaiKhoan, model.MatKhau);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { message = "Đăng nhập thành công", taikhoan = user.TenTaiKhoan/*, token = user.token*/ });
        }

        [Route("get-by-id/{MaTaiKhoan}")]
        [HttpGet]
        public TaiKhoanModel GetDatabyID(string MaTaiKhoan)
        {
            return _taiKhoanBusiness.GetDatabyID(MaTaiKhoan);
        }

        [Route("create-taikhoan")]
        [HttpPost]
        public TaiKhoanModel CreateItem( TaiKhoanModel model)
        {
            _taiKhoanBusiness.Create(model);
            return model;
        }

        [Route("update-taikhoan")]
        [HttpPut]
        public TaiKhoanModel UpdateItem([FromBody] TaiKhoanModel model)
        {
            _taiKhoanBusiness.Update(model);
            return model;
        }

        [Route("taikhoan-getall")]
        [HttpGet]
        public List<TaiKhoanModel> GetAll()
        {
            return _taiKhoanBusiness.GetAll();
        }


        [Route("Delete-taikhoan")]
        [HttpDelete]
        public IActionResult DeleteItem(string MaKhachHang)
        {
            _taiKhoanBusiness.Delete(MaKhachHang);
            return Ok(new { message = "Xóa thành công" });
        }

    }

}