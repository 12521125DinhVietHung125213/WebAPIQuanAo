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

        public DanhMucModel GetAll()
        {
            string msgErrror = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgErrror, "sp_danhmuc_get_all");
                if (!string.IsNullOrEmpty(msgErrror))
                    throw new Exception(msgErrror);
                return dt.ConvertTo<DanhMucModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 




    }
}
