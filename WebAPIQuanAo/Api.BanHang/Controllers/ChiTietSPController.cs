using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietSPController : Controller
    {
        private IChiTietSPBusiness _CTSPBusiness;
        public ChiTietSPController(IChiTietSPBusiness CTSPBusiness)
        {
            _CTSPBusiness = CTSPBusiness;
        }

        [Route("get-by-id/{ChiTietSanPham}")]
        [HttpGet]
        public ChiTietSPModel GetDatabyID(string MaChiTietSanPham)
        {
            return _CTSPBusiness.GetDatabyID(MaChiTietSanPham);
        }
        [Route("get-all")]
        [HttpGet]
        public List<ChiTietSPModel> GetAll()
        {
            return _CTSPBusiness.GetAll();
        }

        [Route("create-ChiTietSanPham")]
        [HttpPost]
        public ChiTietSPModel CreateItem([FromBody] ChiTietSPModel model)
        {
            _CTSPBusiness.Create(model);
            return model;
        }

        [Route("update-ChiTietSanPham")]
        [HttpPut]
        public ChiTietSPModel UpdateItem([FromBody] ChiTietSPModel model)
        {
            _CTSPBusiness.Update(model);
            return model;
        }



        [Route("Delete-ChiTietSanPham")]
        [HttpDelete]
        public IActionResult DeleteItem(string MaKhachHang)
        {
            _CTSPBusiness.Delete(MaKhachHang);
            return Ok(new { message = "Xóa thành công" });
        }


        
    }
}
