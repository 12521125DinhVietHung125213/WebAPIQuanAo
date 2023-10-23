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

        [Route("create-SanPham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }

        [Route("update-SanPham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }

        [Route("Delete-SanPham")]
        [HttpPost]
        public SanPhamModel DeleteItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Delete(model);
            return model;
        }

    }
}
