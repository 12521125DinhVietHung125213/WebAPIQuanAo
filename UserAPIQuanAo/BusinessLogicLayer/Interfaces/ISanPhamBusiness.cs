using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetDatabyID(string id);
        List<SanPhamModel> GetAll();
        List<SanPhamBanChayModel> Top3banchay();
        public List<SeachTheoTenModel> SearchTheoTen(int pageIndex, int pageSize, string TenSanPham);
    }
}
