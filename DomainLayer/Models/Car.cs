using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    [Table(name: "CarTable")]
    public class Car
    {
        [Key]
        [Column(TypeName = "Int")]
        public int carKey { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String ownerID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public String Brand { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public String Model { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String SerialNum { get; set; }

        [Required]
        [Column(TypeName = "Int")]
        public int ReleaseYear { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public String vinCode { get; set; }

        [Required]
        [Column(TypeName = "Float")]
        public float Price { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "Bit")]
        public bool IsActive { get; set; } = false;


    }
}
