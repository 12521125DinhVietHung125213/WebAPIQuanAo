using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface IDanhMucRepository
    {
        DanhMucModel GetDatabyID(string id);
        List<DanhMucModel> GetAll();
        bool Create(DanhMucModel model);
        bool Update(DanhMucModel model);    
        bool Delete(DanhMucModel model);

    }
}
