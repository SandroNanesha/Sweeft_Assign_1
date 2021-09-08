using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    [DataContract]
    public class CarDTO
    {

        [DataMember]
        public String ownerID { get; set; }
        [DataMember]
        public String Brand { get; set; }
        [DataMember]
        public String Model { get; set; }
        [DataMember]
        public String SerialNum { get; set; }
        [DataMember]
        public int ReleaseYear { get; set; }
        [DataMember]
        public String vinCode { get; set; }
        [DataMember]
        public float Price { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
    }
}
