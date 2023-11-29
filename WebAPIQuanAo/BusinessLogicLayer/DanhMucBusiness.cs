using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer
{
    public class DanhMucBusiness:IDanhMucBusiness
    {
        private IDanhMucRepository _res;
        public DanhMucBusiness(IDanhMucRepository res)
        {
            _res = res;
        }
        public DanhMucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DanhMucModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(DanhMucModel model)
        {
            return _res.Create(model);
        }

        public bool Delete(string MaDanhMuc)
        {
            return _res.Delete(MaDanhMuc);
        }

        public bool Update(DanhMucModel model)
        {
            return _res.Update(model);
        }

        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string DanhMucCha, string TenDanhMuc)
        {
            return _res.Search(pageIndex, pageSize, out total, DanhMucCha, TenDanhMuc);
        }
    }
}
