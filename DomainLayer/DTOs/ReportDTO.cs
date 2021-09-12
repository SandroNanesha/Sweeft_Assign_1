using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace DomainLayer.DTOs
{
    public class ReportDTO
    {
        
        public DateTime monthYear { get; set; }
        public int SumOfSoldCars { get; set; }

        public float SumOfIncome { get; set; }

        public float AveIncome { get; set; }


    }
}
