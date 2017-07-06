using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IPService
{
    public class IPService : IIPService
    {
        static List<IP> IPs = new List<IP>()
        {
            new IP("1.1.1.1", "Ones") { ID = 1 },
            new IP("5.5.5.5", "Fives") { ID = 2 }
        };

        public void DeleteIP(int id)
        {
            IPs.Remove(IPs.First(ip => ip.ID == id));
        }

        public IEnumerable<IP> GetAllIPs()
        {
            return IPs;
        }

        public void InsertIP(IP ip)
        {
            var maxID = IPs.Max(x => x.ID);
            ip.ID = maxID + 1;
            IPs.Add(ip);
        }
    }
}
