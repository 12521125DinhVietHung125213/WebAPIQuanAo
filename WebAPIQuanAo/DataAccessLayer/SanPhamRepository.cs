using DataAccessLayer.Interfaces;
using DataModel;

namespace DataAccessLayer
{
    public class SanPhamRepository:ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public SanPhamModel GetDatabyID(string MaSanPham)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_SanPham_get_by_id",
                     "@MaSanPham", MaSanPham);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SanPhamModel GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_sanpham_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                   out msgError,
                   "sp_SanPham_create",
               "@MaDanhMuc", model.MaDanhMuc,
               "@TenSanPham", model.TenSanPham,
               "@Gia", model.Gia,
               "@SoLuong", model.SoLuong,
               "@MauSac", model.MauSac);
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
        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_SanPham_update",
               "@MaDanhMuc", model.MaDanhMuc,
               "@TenSanPham", model.TenSanPham,
               "@Gia", model.Gia,
               "@SoLuong", model.SoLuong,
               "@MauSac", model.MauSac);
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

        public bool Delete(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_SanPham_get_by_id",
                "@MaSanPham", model.MaSanPham);
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
