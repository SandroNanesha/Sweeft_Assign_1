using DomainLayer.DTOs;
using DomainLayer.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using ServicesLayer.ClientService;
using ServicesLayer.Validators.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SweeftAutoMartket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ClientValidator _clientValidator;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _clientValidator = new ClientValidator();
            _logger = logger;
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(String id)
        {
            _logger.LogInformation("In {controller} Get Method invoked", this.GetType().Name);

            try
            {
                ClientDTO currClientDTO = new ClientDTO();
                currClientDTO.ID = id;
                var valid = _clientValidator.Validate(currClientDTO, options => options.IncludeRuleSets("idChecker"));

                if (!String.IsNullOrEmpty(id) && valid.IsValid)
                    return await _clientService.GetSingle(id);

                _logger.LogWarning("Invalid input");
                
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                
                throw e;
            }
        }

        [HttpPost]
        [Route(nameof(PostClient))]
        public async Task<ActionResult> PostClient([FromBody] ClientDTO clientDTO)
        {
            _logger.LogInformation("In {controller} Post Method invoked", this.GetType().Name);

            try
            {
                var valid = _clientValidator.Validate(clientDTO);
                if (valid.IsValid)
                {
                    await _clientService.AddClient(clientDTO);
                    return Ok(clientDTO);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(String id)
        {
            _logger.LogInformation("In {controller} Delete Method invoked", this.GetType().Name);
            try
            {
                ClientDTO currClientDTO = new ClientDTO();
                currClientDTO.ID = id;
                var valid = _clientValidator.Validate(currClientDTO, options => options.IncludeRuleSets("idChecker"));
                if (!String.IsNullOrEmpty(id) && valid.IsValid)
                {
                    await _clientService.DeleteClient(id);
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

        [HttpPut]
        public async Task<ActionResult> UpdateInfo([FromBody] ClientDTO currClientDTO)
        {
            _logger.LogInformation("In {controller} Update Method invoked", this.GetType().Name);

            try

            {
                var valid = _clientValidator.Validate(currClientDTO);
                if (valid.IsValid)
                {
                    await _clientService.UpdateClientInfo(currClientDTO);

                    return Ok(currClientDTO);
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
