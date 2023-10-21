using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using System.Reflection;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        } 
        public SanPhamModel GetChiTietSanPham(int id)
        {
            return _res.GetChiTietSanPham(id);
        } 
    }
}