namespace Poc.Distributed.Application.Business.Domain.Entities
{
    public class User
    {
        public User(int userId, string nome, string email)
        {
            UserId = userId;
            Nome = nome;
            Email = email;
        }

        public int UserId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
