using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    [DataContract]
    public class ClientDTO
    {   
        [DataMember]
        public String ID { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public String Tel { get; set; }
        [DataMember]
        public String mail { get; set; }
        [DataMember]
        public String Address { get; set; }
    }
}
