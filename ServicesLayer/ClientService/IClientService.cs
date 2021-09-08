using DomainLayer.DTOs;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.ClientService
{
    public interface IClientService
    {
        Task<Client> AddClient(Client newClient);

        Task UpdateClientInfo(Client currClient);

        Task DeleteClient(Client currClient);

        Task<Client> GetSingle(Client currClient);


    }
}
