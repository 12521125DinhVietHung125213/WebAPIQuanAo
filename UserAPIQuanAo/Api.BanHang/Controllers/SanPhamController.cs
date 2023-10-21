using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanPhamBusiness;
        public SanPhamController(ISanPhamBusiness sanPhamBusiness)
        {
            _sanPhamBusiness = sanPhamBusiness;
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(int id)
        {
            return _sanPhamBusiness.GetChiTietSanPham(id);
        } 
    }
}
