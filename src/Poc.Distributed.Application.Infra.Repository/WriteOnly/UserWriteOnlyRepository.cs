using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Poc.Distributed.Application.Business.Domain.Interfaces;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Infra.Repository.WriteOnly
{
    public class UserWriteOnlyRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserWriteOnlyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> InsertUserAsync(Business.Domain.Entities.User user)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("Sql"));
            Entities.UserWriteOnly userPersistence = user;
            return await connection.InsertAsync(userPersistence);
        }
    }
}
