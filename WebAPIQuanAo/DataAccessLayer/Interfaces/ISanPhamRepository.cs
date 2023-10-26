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
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, string ten_san_pham, string gia);
    }
}
