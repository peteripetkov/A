using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IPService
{
    [ServiceContract]
    public interface IIPService
    {
        [OperationContract]
        void InsertIP(IP ip);

        [OperationContract]
        void DeleteIP(int id);
        
        [OperationContract]
        IEnumerable<IP> GetAllIPs();
    }

    [DataContract]
    public class IP
    {
        [DataMember]
        public int ID;

        [DataMember]
        public string Address;

        [DataMember]
        public string Name;

        public IP(string address, string name)
        {
            Address = address;
            Name = name;
        }
    }
}
