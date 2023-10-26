using DataAccessLayer.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DanhMucRepository:IDanhMucRepository
    {
        private IDatabaseHelper _dbHelper;
        public DanhMucRepository(IDatabaseHelper dbHelper)
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

        public List<DanhMucModel> GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_danhmuc_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<DanhMucModel>().ToList();
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
        public List<DanhMucModel> Search(int pageIndex, int pageSize, out long total, string DanhMucCha, string TenDanhMuc)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_danhmuc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@danh_muc_cha", DanhMucCha,
                    "@ten_danh_muc", TenDanhMuc);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DanhMucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
