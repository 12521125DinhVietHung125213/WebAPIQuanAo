using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonBusiness
    {
        bool Create(HoaDonModel model);
        HoaDonModel GetDatabyID(string id);

        bool Update(HoaDonModel model);
        bool Delete(string MaHoaDon);
        public List<ThongKeHoaDonModel> Search(int pageIndex, int pageSize, out long total, string ten_khach_hang, DateTime? fr_NgayTao, DateTime? to_NgayDuyet);
    }
}
