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

        [Route("get-by-id/{MaSanPham}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(string MaSanPham)
        {
            return _sanPhamBusiness.GetDatabyID(MaSanPham);
        }

        [Route("get-all")]
        [HttpGet]
        public SanPhamModel GetAll()
        {
            return _sanPhamBusiness.GetAll();
        }

        [Route("get-Top3banchay")]
        [HttpGet]
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }



    }
}
