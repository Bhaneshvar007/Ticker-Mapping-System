using Cylsys.Common;
using MicroORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cash_Future_MappingSystem.BAL
{
    public class FileMaster
    {
        public List<FileMasterModel> GetFileData()
        {
            SqlParameter[] Params = { new SqlParameter("@Action", "") };
            
            DataTable DT = DataAccess.ExecuteProcedure("sp_GetFileMaster", null);
            return QueryHandler.GetFileData(DT);
        }

        public bool DeleteFile(int id)
        {
            try
            {
                DataAccess.ExecuteQuery($"delete from cftms_tbl_file_master where id = {id}");
                return true;
            }
            catch (Exception ex)
            {
                Helper.WriteLog(ex.ToString());
                return false;
            }
        }
    }
}