using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{

    public class CarDTO
    {

        
        public String ownerID { get; set; }
        
        public String Brand { get; set; }
        
        public String Model { get; set; }
        
        public String SerialNum { get; set; }
        
        public int ReleaseYear { get; set; }
        
        public String vinCode { get; set; }
        
        public float Price { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
    }
}
