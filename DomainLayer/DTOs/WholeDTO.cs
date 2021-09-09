using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    public class WholeDTO
    {

        public String ID { get; set; }

        public String Name { get; set; }

        public String LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public String Tel { get; set; }

        public String mail { get; set; }

        public String Address { get; set; }

        public String ownerID { get; set; }
        
        public String Brand { get; set; }
        
        public String Model { get; set; }
        
        public String SerialNum { get; set; }
        
        public int ReleaseYear { get; set; }
        
        public String vinCode { get; set; }
        
        public float Price { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public bool ForSale { get; set; }
    }
}
