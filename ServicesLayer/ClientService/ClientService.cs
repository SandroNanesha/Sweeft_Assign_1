using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer;
using ServicesLayer.Validators.DBValidators;
using ServicesLayer.Validators.FluentValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ClientService
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly ClientDBValidator _dbValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;

        public ClientService(ApplicationDbContext context, IMapper mapper, ILogger<ClientService> logger)
        {
            _context = context;
            _dbValidator = new ClientDBValidator(_context);
            _mapper = mapper;
            _logger = logger;
        }
        public async Task AddClient(ClientDTO newClientDTO)
        {
            
            if (!_dbValidator.IsActive(newClientDTO))
            {
                Client newClient = _mapper.Map<Client>(newClientDTO);
                _context.clients.AddAsync(newClient);

            } else
            {
                _logger.LogWarning("Client with id {id) is already in database", newClientDTO.ID);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(String clientID)
        {
            ClientDTO currClientDTO = new ClientDTO();
            currClientDTO.ID = clientID;

            if (_dbValidator.IsActive(currClientDTO))
            {
                Client currClient = await _context.clients.Where(clt => clt.ID == clientID && clt.IsActive).FirstOrDefaultAsync();

                currClient.IsActive = false;
            } else
            {
                _logger.LogWarning("Client with id {id) is not active in database", currClientDTO.ID);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<ClientDTO> GetSingle(String clientID)
        { 
            
            Client foundClient = await _context.clients.Where(clt => clt.ID == clientID && clt.IsActive).FirstOrDefaultAsync();

            return _mapper.Map<ClientDTO>(foundClient);
        }


        public async Task UpdateClientInfo(ClientDTO currClientDTO)
        {
            if (_dbValidator.IsActive(currClientDTO))
            {
                Client currClient = _mapper.Map<Client>(currClientDTO);
                
                _context.clients.Update(currClient);
                
            } else
            {
                _logger.LogWarning("Client with id {id) is not in database", currClientDTO.ID);
            }

            await _context.SaveChangesAsync();
        }
            
    }
}