using DataModel;

namespace DataAccessLayer
{
    public class HoaDonRepository:IHoaDonRepository
    {
        private IDatabaseHelper _dbHelper;
        public HoaDonRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public bool Create(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var xxx = model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null;
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoadon_create",
                "@TenKH", model.TenKH,
                "@Diachi", model.Diachi,
                "@TrangThai", model.TrangThai,
                "@NgayTao",model.Ngaytao,
                "@Sđt",model.Sđt,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public HoaDonModel GetDatabyID(string MaHoaDon)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_hoadon_get_by_id",
                     "@MaHoaDon", MaHoaDon);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<HoaDonModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(HoaDonModel model)
        {
            string msgError = "";
            try
            {
                var xxx = model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null;
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_hoa_don_update",
                "@MaHoaDon",model.MaHoaDon,
                "@TenKH", model.TenKH,
                "@Diachi", model.Diachi,
                "@TrangThai", model.TrangThai,
                "@NgayTao", model.Ngaytao,
                "@Sđt", model.Sđt,
                "@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
