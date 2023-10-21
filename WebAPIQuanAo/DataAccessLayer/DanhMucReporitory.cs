using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DanhMucReporitory:IDanhMucReporitory
    {
        private IDatabaseHelper _dbHelper;
        public DanhMucReporitory(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public DanhMucModel GetDatabyID(string MaDanhMuc)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_DanhMuc_get_by_id",
                     "@MaDanhMuc", MaDanhMuc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DanhMucModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DanhMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                   out msgError,
                   "sp_DanhMuc_create",
               "@DanhMucCha", model.DanhMucCha,
               "@TenDanhMuc", model.TenDanhMuc);
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

        public bool Update(DanhMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(
                    out msgError,
                    "sp_DanhMuc_create",
                "@MaDanhMuc" , model.MaDanhMuc,
               "@DanhMucCha", model.DanhMucCha,
               "@TenDanhMuc", model.TenDanhMuc);
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
        public bool Delete(DanhMucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_DanhMuc_delete",
                "@MaDanhMuc", model.MaDanhMuc);
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
