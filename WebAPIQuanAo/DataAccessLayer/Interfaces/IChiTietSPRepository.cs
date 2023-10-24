using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IChiTietSPRepository
    {
        ChiTietSPModel GetDatabyID(string id);
        List<ChiTietSPModel> GetAll();
        bool Create(ChiTietSPModel model);
        bool Update(ChiTietSPModel model);
        bool Delete(string MaChiTietSanPham);
    }
}
