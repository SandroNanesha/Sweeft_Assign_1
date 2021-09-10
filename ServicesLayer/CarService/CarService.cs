using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using ServicesLayer.Validators.DBValidators;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public async Task<IEnumerable<WholeDTO>> GetInRange(DateDTO fromTo)
        {
            DateTime from = toDateTime(fromTo.StartDate);
            DateTime to = toDateTime(fromTo.EndDate);

            List<Car> foundCars = await _context.cars.Where(car => car.IsActive && car.StartDate >= from  && car.EndDate <= to).ToListAsync();
            List<WholeDTO> responseInfo = new List<WholeDTO>();

            foreach(var car in foundCars)
            {
                WholeDTO currCarInfo = _mapper.Map<WholeDTO>(car);
                Client currClient = await _context.clients.Where(clt => clt.ID == car.ownerID).FirstOrDefaultAsync();
                currCarInfo = _mapper.Map<WholeDTO>(currClient);
                responseInfo.Add(currCarInfo);
            }
            return responseInfo;
        }

        private DateTime toDateTime(String txtDate)
        {
            DateTime dt;
            bool isValid = DateTime.TryParseExact(txtDate, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);

            return dt;
    
        }

        public async Task<bool> UpdateCarInfo(String vinCode)
        {
            bool success = false;
            Car currCar = await _context.cars.Where(car => car.vinCode == vinCode && car.IsActive && car.ForSale).FirstOrDefaultAsync();

            if (currCar != null)
            {
                currCar.ForSale = false;

                _context.cars.Update(currCar);
                success = true;

            }
            else
            {
                _logger.LogWarning("Car with vinCode {vinCode) is not in database", vinCode);
                
            }

            await _context.SaveChangesAsync();
            return success;

        }
    }
}
