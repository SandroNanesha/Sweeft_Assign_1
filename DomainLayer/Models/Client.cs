using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table(name: "ClientTable")]
    public class Client
    {
        [Key]
        [Column(TypeName = "Int")]
        public int clientKey { get; set; } = 0;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String ID { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public String LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Tel { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String mail { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Address { get; set; }

        [Column(TypeName = "Bit")]
        public bool IsActive { get; set; } = true;
    }
}
