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
        Task AddClient(ClientDTO newClient);

        Task UpdateClientInfo(ClientDTO currClient);

        Task DeleteClient(String clientID);

        Task<ClientDTO> GetSingle(String clientID);


    }
}
