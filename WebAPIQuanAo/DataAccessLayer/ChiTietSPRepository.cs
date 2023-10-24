using DataModel;

namespace DataAccessLayer
{
    public class ChiTietSPRepository : IChiTietSPRepository
    {
        private IDatabaseHelper _dbHelper;
        public ChiTietSPRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ChiTietSPModel GetDatabyID(string MaChiTietSanPham)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_CTHD_get_by_id",
                     "@MaChiTietSanPham",MaChiTietSanPham );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietSPModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChiTietSPModel> GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_ctsanpham_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<ChiTietSPModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(ChiTietSPModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                   out msgError,
                   "sp_CTSanPham_create",
                "@maSanPham", model.MaSanPham,
                "@moTa", model.MoTa,
                "@chiTiet", model.ChiTiet);
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
        public bool Update(ChiTietSPModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_CTSanPham_update",
                "@maChiTietSanPham", model.MaChiTietSanPham,
                "@maSanPham", model.MaSanPham,
                "@moTa", model.MoTa,
                "@chiTiet", model.ChiTiet);
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
        public bool Delete(string MaChiTietSanPham)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SanPham_update",
                "@MaChiTietSanPham", MaChiTietSanPham);
                ;
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
