using DataAccessLayer.Interfaces;
using DataModel;

namespace DataAccessLayer
{
    public class TaiKhoanRepository:ITaiKhoanRepository
    {
        private IDatabaseHelper _dbHelper;
        public TaiKhoanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public TaiKhoanModel Login(string taikhoan, string matkhau)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_login",
                     "@tendangnhap", taikhoan,
                     "@matkhau", matkhau
                     );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TaiKhoanModel GetDatabyID(string MaTaiKhoan)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_TaiKhoan_get_by_id",
                     "@maTaiKhoan", MaTaiKhoan);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TaiKhoanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(TaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                   out msgError,
                   "sp_taikhoan_create",
               "@loaitaikhoan", model.LoaiTaiKhoan,
               "@tentaikhoan", model.TenTaiKhoan,
               "@matkhau", model.MatKhau,
               "@Sđt", model.SĐT,
               "@Email", model.Email);
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

        public bool Update(TaiKhoanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                      "sp_TaiKhoan_update",
                "@mataikhoan" ,model.MaTaiKhoan,
               "@loaitaikhoan", model.LoaiTaiKhoan,
               "@tentaikhoan", model.TenTaiKhoan,
               "@matkhau", model.MatKhau,
               "@Sđt", model.SĐT,
               "@Email", model.Email);
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
        public bool Delete(string MaTaiKhoan)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_Taikhoan_delete",
                "@mataikhoan", MaTaiKhoan);
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