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
        List<SanPhamBanChayModel> Top3banchay();
        List<SanPhamModel> GetAll();
        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string TenSanPham);
    }
}
