using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OdataJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestStudentServiceImpl" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RestStudentServiceImpl.svc or RestStudentServiceImpl.svc.cs at the Solution Explorer and start debugging.
    public class RestStudentServiceImpl : IRestStudentServiceImpl
    {
        public void DoWork()
        {
        }

        BasicCRUDFunsDAL crestLoginDAL = new BasicCRUDFunsDAL();
        List<BasicCRUDFuns> cl = new List<BasicCRUDFuns>();

        public IEnumerable<BasicCRUDFuns> GetAll()
        {
            DataSet _dsLD = crestLoginDAL.GetAll();
            /**/
            if (_dsLD.Tables[0].Columns.Count > 1)
            {
                DataTable dtTable = (DataTable)_dsLD.Tables[0];
                cl = ConvertDataTable<BasicCRUDFuns>(dtTable);
                /**/
                return cl;
                /**/
            }
            else
            {
                # region Login Detais
                return null;
                #endregion
            }
            /**/

        }

        public IEnumerable<BasicCRUDFuns> GetById(string id)
        {
            DataSet _dsLD = crestLoginDAL.GetById(Int32.Parse(id));
            /**/
            if (_dsLD.Tables[0].Columns.Count > 1)
            {
                DataTable dtTable = (DataTable)_dsLD.Tables[0];
                cl = ConvertDataTable<BasicCRUDFuns>(dtTable);
                /**/
                return cl;
                /**/
            }
            else
            {
                # region Login Detais
                return null;
                #endregion
            }
        }


        public string insertDetails(List<BasicCRUDFuns> MItems)
        {
            DataSet _dsLD = new DataSet();
            foreach(BasicCRUDFuns smitems in MItems){
             _dsLD = crestLoginDAL.insertDetails(smitems);
            /**/
           
            }
            //if (_dsLD.Tables[0].Columns.Count != 0)
            //{
            //    //DataTable dtTable = (DataTable)_dsLD.Tables[0];
            //    //cl = ConvertDataTable<BasicCRUDFuns>(dtTable);
            //    ///**/
            //    return "Success";
            //    /**/
            //}
            //else
            //{
            //    # region Login Detais
            //    return "Failure";
            //    #endregion
            //}
            /**/
            return "Success";
        }

        #region ""Data set to list"
        /**/
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)

                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        #endregion "Data set to list"
    }
}
