using MediatR;

namespace Poc.Distributed.Application.Business.Application
{
    public class InsertUserCommandRequest : IRequest<InsertUserCommandResponse>
    {
        public InsertUserCommandRequest(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        public string Nome { get; }
        public string Email { get; }
    }
}
