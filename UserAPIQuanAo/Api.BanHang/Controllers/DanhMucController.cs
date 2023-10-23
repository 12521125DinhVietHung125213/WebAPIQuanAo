using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhMucController : Controller
    {
        private IDanhMucBusiness _danhMucBusiness;
        public DanhMucController(IDanhMucBusiness danhMucBusiness)
        {
            _danhMucBusiness = danhMucBusiness;
        }

        [Route("get-by-id/{MaDanhMuc}")]
        [HttpGet]
        public DanhMucModel GetDatabyID(string MaDanhMuc)
        {
            return _danhMucBusiness.GetDatabyID(MaDanhMuc);
        }
        [Route("get-all")]
        [HttpGet]
        public DanhMucModel GetAll()
        {
            return _danhMucBusiness.GetAll();
        }
    }
}
