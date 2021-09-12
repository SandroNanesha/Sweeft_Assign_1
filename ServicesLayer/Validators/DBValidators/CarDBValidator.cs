using DomainLayer.DTOs;
using DomainLayer.Models;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.DBValidators
{
    public class CarDBValidator
    {
        private readonly ApplicationDbContext _context;

        public CarDBValidator(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsActive(CarDTO car)
        {
            if (_context.clients.Any(clt => clt.ID == car.ownerID && clt.IsActive == true))
            {
                return _context.cars.Any(cr => cr.vinCode == car.vinCode && cr.IsActive);
            }

            return true;
        }

        public Car getCar(CarDTO car)
        {
            if (_context.clients.Any(clt => clt.ID == car.ownerID && clt.IsActive == true))
            {
                return _context.cars.Where(cr => cr.vinCode == car.vinCode && cr.IsActive).FirstOrDefault();
            }
            return null;
        }

        

    }
}
