using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness : ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
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

        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string TenSanPham)
        {
            return _res.SearchTheoTen(pageIndex, pageSize, TenSanPham);
        }

    }
}