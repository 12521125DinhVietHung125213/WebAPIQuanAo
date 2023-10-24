using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ChiTietSPBusiness: IChiTietSPBusiness
    {
        private IChiTietSPRepository _res;
        public ChiTietSPBusiness(IChiTietSPRepository res)
        {
            _res = res;
        }
        public ChiTietSPModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ChiTietSPModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(ChiTietSPModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ChiTietSPModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string MaChiTietSanPham)
        {
            return _res.Delete(MaChiTietSanPham);
        }
    }
}
