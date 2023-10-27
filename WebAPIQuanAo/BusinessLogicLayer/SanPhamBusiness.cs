using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness (ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SanPhamModel> GetAll()
        {
            return _res.GetAll();
        }
        public List<SanPhamBanChayModel> Top3banchay()
        {
            return _res.Top3banchay();
        }
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(SanPhamModel model)
        { 
            return _res.Delete(model); 
        }
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin)
        {
            return _res.SearchTheoGia(pageIndex, pageSize, out total, giaMax, giaMin);

        }

        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string TenSanPham )
        {
            return _res.SearchTheoTen(pageIndex, pageSize, TenSanPham);
        }

    }
}