using DomainLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.CarService
{
    public interface ICarService
    {
        Task AddCar(CarDTO newCar);

        Task UpdateCarInfo(String vinCode);

        Task DeleteCar(CarDTO currCar);

        Task<IEnumerable<WholeDTO>> GetInRange(CarDTO fromTo);
    }
}
