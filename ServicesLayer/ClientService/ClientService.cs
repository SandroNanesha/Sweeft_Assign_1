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
    class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly ClientValidator _fluentValidator;
        private readonly ClientDBValidator _dbValidator;

        public ClientService(ApplicationDbContext context)
        {
            _context = context;
            _fluentValidator = new ClientValidator();
            _dbValidator = new ClientDBValidator(_context);
        }
        public async Task<Client> AddClient(Client newClient)
        {
            var fluentValid = _fluentValidator.Validate(newClient);

            if(fluentValid.IsValid && !_dbValidator.IsActive(newClient))
            {
                newClient.clientKey = NewClientKey();
                _context.clients.Add(newClient);
            }

            await _context.SaveChangesAsync();
            return newClient;

        }

        public async Task DeleteClient(Client currClient)
        {
            var fluentValid =  _fluentValidator.Validate(currClient, options => options.IncludeRuleSets("idChecker"));

            if (fluentValid.IsValid && _dbValidator.IsActive(currClient))
            {
                currClient.IsActive = false;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetSingle(Client currClient)
        {
            var fluentValid = _fluentValidator.Validate(currClient, options => options.IncludeRuleSets("idChecker"));

            if (fluentValid.IsValid && _dbValidator.IsActive(currClient))
            {
                //BLA
            }
            return await _context.clients.Where(clt => clt.ID == currClient.ID).Where(clt => clt.IsActive).FirstOrDefaultAsync();
        }
        public async Task UpdateClientInfo(Client currClient)
        {
            var fluentValid = _fluentValidator.Validate(currClient, options => options.IncludeRuleSets("idChecker"));

            if (fluentValid.IsValid && _dbValidator.IsActive(currClient))
            {
                _context.clients.Update(currClient);
            }

            await _context.SaveChangesAsync();
        }

        private static int NewClientKey()
        {
            
            return 0;
        }
            
    }
}
