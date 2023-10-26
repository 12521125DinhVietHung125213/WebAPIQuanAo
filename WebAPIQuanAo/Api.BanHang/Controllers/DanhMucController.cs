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
        public List<DanhMucModel> GetAll()
        {
            return _danhMucBusiness.GetAll();
        }

        [Route("create-DanhMuc")]
        [HttpPost]
        public DanhMucModel CreateItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Create(model);
            return model;
        }

        [Route("update-DanhMuc")]
        [HttpPut]
        public DanhMucModel UpdateItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Update(model);
            return model;
        }



        [Route("Delete-DanhMuc")]
        [HttpDelete]
        public DanhMucModel DeleteItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Delete(model);
            return model;
        }

        [Route("Search-DanhMuc")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string DanhMucCha = "";
                if (formData.Keys.Contains("danh_muc_cha") && !string.IsNullOrEmpty(Convert.ToString(formData["danh_muc_cha"]))) { DanhMucCha = Convert.ToString(formData["danh_muc_cha"]); }
                string TenDanhMuc = "";
                if (formData.Keys.Contains("ten_danh_muc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_danh_muc"]))) { TenDanhMuc = Convert.ToString(formData["ten_danh_muc"]); }
                long total = 0;
                var data = _danhMucBusiness.Search(page, pageSize, out total, DanhMucCha, TenDanhMuc);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
