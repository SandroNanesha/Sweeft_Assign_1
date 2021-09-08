using DomainLayer.Models;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Validators.DBValidators
{
    public class ClientDBValidator
    {
        private readonly ApplicationDbContext _context;

        public ClientDBValidator(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool IsActive (Client client)
        {
            return !_context.clients.Any(clt => clt.ID == client.ID && clt.IsActive == true);
        }

    }
}
