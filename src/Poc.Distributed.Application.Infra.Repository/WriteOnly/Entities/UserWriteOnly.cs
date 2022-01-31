using Dapper.Contrib.Extensions;

namespace Poc.Distributed.Application.Infra.Repository.Entities
{
    [Table("Users")]
    public class UserWriteOnly
    {
        [Key]
        public int UserId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static implicit operator Business.Domain.Entities.User(UserWriteOnly user)
        {
            if (user is null)
                return null;

            return 
                new Business.Domain.Entities.User(user.UserId, 
                                                  user.Nome, 
                                                  user.Email);
        }

        public static implicit operator UserWriteOnly(Business.Domain.Entities.User user)
        {
            if (user is null)
                return null;

            return
                new UserWriteOnly()
                {
                    UserId = user.UserId,
                    Nome = user.Nome,
                    Email = user.Email
                };
        }
    }
}