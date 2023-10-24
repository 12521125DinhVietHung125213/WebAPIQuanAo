using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
        public partial interface IChiTietSPBusiness
        {
            ChiTietSPModel GetDatabyID(string id);
            List<ChiTietSPModel> GetAll();
            bool Create(ChiTietSPModel model);
            bool Update(ChiTietSPModel model);
            bool Delete(string MaKhachHang);
        }
    
}
