﻿using BusinessLogicLayer;
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

        [Route("create-DanhMuc")]
        [HttpPost]
        public DanhMucModel CreateItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Create(model);
            return model;
        }

        [Route("update-DanhMuc")]
        [HttpPost]
        public DanhMucModel UpdateItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Update(model);
            return model;
        }



        [Route("Delete-DanhMuc")]
        [HttpPost]
        public DanhMucModel DeleteItem([FromBody] DanhMucModel model)
        {
            _danhMucBusiness.Delete(model);
            return model;
        }
    }
}