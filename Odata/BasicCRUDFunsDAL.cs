using CLUBMahindra.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OdataJson
{
    public static class GloabalStaticDeclarationClass
    {
        #region "Class Variables"
        public static string strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["crestconnection"].ToString();
        #endregion "Class Variables"


    }
    public class BasicCRUDFunsDAL
    {
        private SQLHelper objHelper = null;
        private bool _disposed = false;

        public DataSet GetAll()
        {
            SqlParameter[] _spPmts = new SqlParameter[3];

            string tSpName = "USR_MVC_Sample_slct";

            objHelper = new SQLHelper(GloabalStaticDeclarationClass.strConnectionString);

            try
            {

                return objHelper.ExecDataSetProc(tSpName);
            }
            catch (Exception ex)
            {
                throw new Exception("CrestAdmin.Member.GetLoginDetails() : " + ex.Message);
            }
            finally
            {
                _spPmts = null;
            }
        }

        public DataSet GetById(int id)
        {
            SqlParameter[] _spPmts = new SqlParameter[1];

            string tSpName = "USR_MVC_Sample_SlctById";

            objHelper = new SQLHelper(GloabalStaticDeclarationClass.strConnectionString);

            try
            {
                _spPmts[0] = new SqlParameter("@id", id);
                _spPmts[0].Direction = ParameterDirection.Input;
                _spPmts[0].SqlDbType = SqlDbType.Int;

                return objHelper.ExecDataSetProc(tSpName, _spPmts);
            }
            catch (Exception ex)
            {
                throw new Exception("CrestAdmin.Member.GetLoginDetails() : " + ex.Message);
            }
            finally
            {
                _spPmts = null;
            }
        }

        public DataSet insertDetails(BasicCRUDFuns MItems)
        {
            SqlParameter[] _spPmts = new SqlParameter[2];

            string tSpName = "USR_MVC_Sample_Ins";

            objHelper = new SQLHelper(GloabalStaticDeclarationClass.strConnectionString);

            try
            {
                _spPmts[0] = new SqlParameter("@name", MItems.name);
                _spPmts[0].Direction = ParameterDirection.Input;
                _spPmts[0].SqlDbType = SqlDbType.VarChar;

                _spPmts[1] = new SqlParameter("@age", MItems.age);
                _spPmts[1].Direction = ParameterDirection.Input;
                _spPmts[1].SqlDbType = SqlDbType.Int;

                return objHelper.ExecDataSetProc(tSpName, _spPmts);
            }
            catch (Exception ex)
            {
                throw new Exception("CrestAdmin.Member.GetLoginDetails() : " + ex.Message);
            }
            finally
            {
                _spPmts = null;
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // Need to dispose managed resources if being called manually
                if (disposing)
                {
                    if (objHelper != null)
                    {
                        objHelper = null;
                    }
                }
                _disposed = true;
            }
        }

        #endregion
    }
}