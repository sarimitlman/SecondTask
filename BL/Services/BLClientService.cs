using Dal.Models;
using Dal.Api;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Api;

namespace BL.Services
{
    public class BLClientService : IBLClient
    {
        private readonly IClient _dalClient;

        public BLClientService(IClient dalClient)
        {
            _dalClient = dalClient;
        }

        public Task<IEnumerable<Client>> GetAllAsync() => _dalClient.GetAllAsync();
        public Task<Client?> GetByIdAsync(int id) => _dalClient.GetByIdAsync(id);
        public Task AddAsync(Client client) => _dalClient.AddAsync(client);
        public Task UpdateAsync(Client client) => _dalClient.UpdateAsync(client);
        public Task DeleteAsync(int id) => _dalClient.DeleteAsync(id);
    }
}