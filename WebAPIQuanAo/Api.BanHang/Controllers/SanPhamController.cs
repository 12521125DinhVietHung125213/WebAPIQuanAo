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
        public List<SanPhamModel> GetAll()
        {
            return _sanPhamBusiness.GetAll();
        }

        [Route("get-Top3banchay")]
        [HttpGet]
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _sanPhamBusiness.Top3banchay();
        }

        [Route("create-SanPham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Create(model);
            return model;
        }

        [Route("update-SanPham")]
        [HttpPut]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanPhamBusiness.Update(model);
            return model;
        }

        [Route("Delete-SanPham")]
        [HttpDelete]
        public IActionResult DeleteItem(string MaSanPham)
        {
            _sanPhamBusiness.Delete(MaSanPham);
            return Ok(new { message = "Xóa thành công" });
        }

        [Route("Search-Gia")]
        [HttpPost]
        public IActionResult SearchTheoGia([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var max = int.Parse(formData["giamax"].ToString());
                var min = int.Parse(formData["giamin"].ToString());

                long total = 0;
                var data = _sanPhamBusiness.SearchTheoGia(page, pageSize, out total, max, min);
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

        [Route("Search-TenSP")]
        [HttpPost]
        public IActionResult SearchTheoTen([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenSanPham = "";
                if (formData.Keys.Contains("tenSanPham") && !string.IsNullOrEmpty(Convert.ToString(formData["tenSanPham"]))) { TenSanPham = Convert.ToString(formData["tenSanPham"]); }
                var data = _sanPhamBusiness.SearchTheoTen(page, pageSize, TenSanPham);
                return Ok(
                    new
                    {
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
