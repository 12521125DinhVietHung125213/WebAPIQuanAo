using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private IHoaDonBusiness _hoadonBusiness;
        public HoaDonController(IHoaDonBusiness hoadonBusiness)
        {
            _hoadonBusiness = hoadonBusiness;
        }

        [Route("get-by-id/{MaHoaDon}")]
        [HttpGet]
        public HoaDonModel GetDatabyID(string MaHoaDon)
        {
            return _hoadonBusiness.GetDatabyID(MaHoaDon);
        }

        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonModel CreateItem([FromBody] HoaDonModel model)
        {
            _hoadonBusiness.Create(model);
            return model;
        }

        [Route("Update-hoadon")]
        [HttpPost]
        public HoaDonModel UpdateItem([FromBody] HoaDonModel model)
        {
            _hoadonBusiness.Update(model);
            return model;
        }


    }
}
