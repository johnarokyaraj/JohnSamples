using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OdataJson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestStudentServiceImpl" in both code and config file together.
    [ServiceContract]
    public interface IRestStudentServiceImpl
    {
        [OperationContract]

        void DoWork();
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/json")]
         IEnumerable<BasicCRUDFuns> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/json/{id}")]
        IEnumerable<BasicCRUDFuns> GetById(string id);

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Wrapped,
    UriTemplate = "/getjson")]
        [OperationContract]
        string insertDetails(List<BasicCRUDFuns> Employeeobj);
    }

    public class BasicCRUDFuns
    {
        #region Properties
        public Int32 nid
        {
            get;
            set;
        }

        public string name
        { get; set; }

        public Int32 age
        { get; set; }

        #endregion

        public BasicCRUDFuns() { }
    }
}
