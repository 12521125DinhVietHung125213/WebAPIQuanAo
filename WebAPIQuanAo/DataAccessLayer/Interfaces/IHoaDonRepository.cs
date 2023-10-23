using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IHoaDonRepository
    {
        HoaDonModel GetDatabyID(string id );   
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
    }
}
