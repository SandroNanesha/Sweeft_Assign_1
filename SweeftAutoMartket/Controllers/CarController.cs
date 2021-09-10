using DomainLayer.DTOs;
using FluentValidation;
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


        [HttpDelete("{id}/{vinCode}")]
        public async Task<ActionResult> DeleteClient(String id, String vinCode)
        {
            _logger.LogInformation("In {controller} Delete Method invoked", this.GetType().Name);
            try
            {
                CarDTO currCarDto = new CarDTO();
                currCarDto.ownerID = id;
                currCarDto.vinCode = vinCode;

                var valid = _CarValidator.Validate(currCarDto, options => options.IncludeRuleSets("requestChecker"));

                if (valid.IsValid)
                {
                    await _CarService.DeleteCar(currCarDto);
                    return Ok();
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


        [HttpGet]
        [Route(nameof(GetCars))]
        public async Task<IEnumerable<WholeDTO>> GetCars([FromBody] DateDTO fromTo)
        {
            _logger.LogInformation("In {controller} GetCars Method invoked", this.GetType().Name);

            try
            {
                DateValidator dv = new DateValidator();
                var valid = dv.Validate(fromTo);
                if(valid.IsValid)
                {
                  return await _CarService.GetInRange(fromTo);
                }
                else
                {
                    _logger.LogWarning("Invalid input");

                    return null; //bad Request
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                throw e;
            }
        }

        [HttpGet("{vinCode}")]
        [Route(nameof(GetCar))]
        public async Task<ActionResult<bool>> GetCar(String vinCode)
        {
            _logger.LogInformation("In {controller} GetCar Method invoked", this.GetType().Name);

            try
            {
                return await _CarService.UpdateCarInfo(vinCode);
                
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                throw e;
            }
        }

    }
}
