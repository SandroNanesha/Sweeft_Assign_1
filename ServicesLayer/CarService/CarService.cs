using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using ServicesLayer.Validators.DBValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.CarService
{
    class CarService : ICarService
    {
        private readonly ApplicationDbContext _context;
        private readonly CarDBValidator _dbValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<CarService> _logger;

        public CarService(ApplicationDbContext context, IMapper mapper, ILogger<CarService> logger)
        {
            _context = context;
            _mapper = mapper;
            _dbValidator = new CarDBValidator(_context);
            _logger = logger;
        }
        public async Task AddCar(CarDTO newCarDTO)
        {
            if (!_dbValidator.IsActive(newCarDTO))
            {
                Car newCar = _mapper.Map<Car>(newCarDTO);
                
                Guid g = Guid.NewGuid();
                newCar.carKey = g.ToString();

                _context.cars.AddAsync(newCar);
            }
            else
            {
                _logger.LogWarning("Car with vinCode {vinCode) is already in database", newCarDTO.vinCode);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCar(CarDTO currCarDTO)
        {
            if (_dbValidator.IsActive(currCarDTO))
            {
                Car currCar = _mapper.Map<Car>(currCarDTO);

                currCar.IsActive = false;
                _context.cars.Update(currCar);
            }
            else
            {
                _logger.LogWarning("Car with vinCode {vinCode) is not in database", currCarDTO.vinCode);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WholeDTO>> GetInRange(CarDTO fromTo)
        {
            //foreach(var car in )
            //return await _context.cars.Where(car => car.IsActive && car.StartDate >= fromTo.StartDate && car.EndDate <= fromTo.EndDate).ToAsyncList();
            throw new NotImplementedException();
        }

        public async Task UpdateCarInfo(String vinCode)
        { 

            Car currCar = await _context.cars.Where(car => car.vinCode == vinCode && car.IsActive && car.ForSale).FirstOrDefaultAsync();

            if (currCar != null)
            {
                currCar.ForSale = false;

                _context.cars.Update(currCar);

            }
            else
            {
                _logger.LogWarning("Car with vinCode {vinCode) is not in database", vinCode);
            }

            await _context.SaveChangesAsync();

        }
    }
}
