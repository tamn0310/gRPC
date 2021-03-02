using Grpc.Services.Configurations;
using Grpc.Services.Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grpc.Services.Infrastuctures
{
    public interface IUserRepository
    {
        Task<int> InsertAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(int id);

        Task<User> GetAsync(int id);

        Task<IEnumerable<User>> GetPagingAsync(int page, int limit, string search, string sort);
    }

    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly string _connectionString;

        public UserRepository(ILogger<UserRepository> logger, AppConnections appConnections)
        {
            _logger = logger;
            _connectionString = appConnections.DefaultConnection;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetPagingAsync(int page, int limit, string search, string sort)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> InsertAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}