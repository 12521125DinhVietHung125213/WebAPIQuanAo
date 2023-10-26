using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness:IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }
        public HoaDonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }

        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);    
        }

        public bool Delete(string MaHoaDon)
        {
            return _res.Delete(MaHoaDon);
        }
        public List<ThongKeHoaDonModel> Search(int pageIndex, int pageSize, out long total, string ten_khach_hang, DateTime? fr_NgayTao, DateTime? to_NgayDuyet)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach_hang, fr_NgayTao, to_NgayDuyet);
        }

    }
}