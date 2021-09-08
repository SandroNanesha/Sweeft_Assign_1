using DomainLayer.Models;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.DBValidators
{
    public class CarDBVlidator
    {
        private readonly ApplicationDbContext _context;

        public CarDBVlidator(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsValid(Car car)
        {
            return !_context.cars.Any(cr => cr.vinCode == car.vinCode && cr.IsActive == true);
        }

    }
}
