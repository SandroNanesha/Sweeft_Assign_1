using DomainLayer.DTOs;
using DomainLayer.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.ClientService;
using ServicesLayer.Validators.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweeftAutoMartket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ClientValidator _clientValidator;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
            _clientValidator = new ClientValidator();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(String id)
        {
            try
            {
                ClientDTO currClientDTO = new ClientDTO();
                currClientDTO.ID = id;
                var valid = _clientValidator.Validate(currClientDTO, options => options.IncludeRuleSets("idChecker"));

                if (!String.IsNullOrEmpty(id) && valid.IsValid)
                    return await _clientService.GetSingle(id);

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route(nameof(PostClient))]
        public async Task<ActionResult> PostClient([FromBody] ClientDTO clientDTO)
        {

            try
            {
                var valid = _clientValidator.Validate(clientDTO);
                if (valid.IsValid)
                {
                    await _clientService.AddClient(clientDTO);
                    return Ok(clientDTO);
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(String id)
        {
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
                return BadRequest();   
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateInfo([FromBody] ClientDTO currClientDTO)
        {

            try

            {
                var valid = _clientValidator.Validate(currClientDTO);
                if (valid.IsValid)
                {
                    await _clientService.UpdateClientInfo(currClientDTO);

                    return Ok(currClientDTO);
                }

                return BadRequest();
            }

            catch (Exception)
            {

                throw;
            }
        }

    }
}
