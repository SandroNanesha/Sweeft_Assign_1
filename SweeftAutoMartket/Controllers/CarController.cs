using DomainLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicesLayer.CarService;
using ServicesLayer.Validators.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftAutoMartket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _CarService;
        private readonly CarValidator _CarValidator;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarService CarService, ILogger<CarController> logger)
        {
            _CarService = CarService;
            _CarValidator = new CarValidator();
            _logger = logger;
            
        }

        [HttpPost]
        [Route(nameof(PostCar))]
        public async Task<ActionResult> PostCar([FromBody] CarDTO CarDTO)
        {
            _logger.LogInformation("In {controller} Post Method invoked", this.GetType().Name);

            try
            {
                var valid = _CarValidator.Validate(CarDTO);
                if (valid.IsValid)
                {
                    await _CarService.AddCar(CarDTO);
                    return Ok(CarDTO);
                }

                _logger.LogWarning("Invalid input");
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw e;
            }

        }
        
    }
}
