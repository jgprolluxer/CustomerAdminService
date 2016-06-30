using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Prollux.CustomerAdmin.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProlluxCustomerAdmin
    {
        [OperationContract]
        ResultData IsValidClient(ClientData composite);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ClientData
    {
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public string UserName { get; set; }
    }

    [DataContract]
    public class ResultData
    {
        [DataMember]
        public bool Valid { get; set; }
        [DataMember]
        public string Error { get; set; }
    }
}
