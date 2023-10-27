using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetDatabyID(string id);

        List<SanPhamModel> GetAll();
        List<SanPhamBanChayModel> Top3banchay();
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);    

        bool Delete(SanPhamModel model);
        public List<SanPhamModel> SearchTheoGia(int pageIndex, int pageSize, out long total, int giaMax, int giaMin);

        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string TenSanPham);
    }
}
