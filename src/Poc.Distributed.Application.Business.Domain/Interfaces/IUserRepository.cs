using Poc.Distributed.Application.Business.Domain.Entities;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Business.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertUserAsync(User user);
    }
}
