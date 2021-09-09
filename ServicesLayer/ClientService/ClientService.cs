using AutoMapper;
using DomainLayer.DTOs;
using DomainLayer.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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

        public ClientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _dbValidator = new ClientDBValidator(_context);
            _mapper = mapper;
        }
        public async Task AddClient(ClientDTO newClientDTO)
        {
            
            if (!_dbValidator.IsActive(newClientDTO))
            {
                Client newClient = _mapper.Map<Client>(newClientDTO);
                
                Guid g = Guid.NewGuid();
                newClient.clientKey = g.ToString();
                
                _context.clients.AddAsync(newClient);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(String clientID)
        {
            ClientDTO currClientDTO = new ClientDTO();
            currClientDTO.ID = clientID;

            if (_dbValidator.IsActive(currClientDTO))
            {
                Client currClient = _mapper.Map<Client>(currClientDTO);
                
                currClient.IsActive = false;
                _context.clients.Update(currClient);
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
                
            }

            await _context.SaveChangesAsync();
        }
            
    }
}
