using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTOs
{
    
    public class ClientDTO
    {   
        
        public String ID { get; set; }
        
        public String Name { get; set; }
        
        public String LastName { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public String Tel { get; set; }
        
        public String mail { get; set; }
        
        public String Address { get; set; }
    }
}
