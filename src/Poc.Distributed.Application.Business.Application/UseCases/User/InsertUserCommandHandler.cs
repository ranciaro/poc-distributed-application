using MediatR;
using Poc.Distributed.Application.Business.Domain.Events;
using Poc.Distributed.Application.Business.Domain.Interfaces;
using Silverback.Messaging.Publishing;
using System.Threading;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Business.Application
{
    public class InsertUserCommandHandler : IRequestHandler<InsertUserCommandRequest, InsertUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private Silverback.Messaging.Publishing.IPublisher _publisher;

        public InsertUserCommandHandler(IUserRepository userRepository, Silverback.Messaging.Publishing.IPublisher publisher)
        {
            _userRepository = userRepository;
            _publisher = publisher;
        }

        public async Task<InsertUserCommandResponse> Handle(InsertUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.InsertUserAsync(new Domain.Entities.User(0, request.Nome, request.Email));
            SqlInsertedEvent sqlInsertedEvent = CreateSqlInsertedEvent(request, result);
            await _publisher.PublishAsync(sqlInsertedEvent);
            return new InsertUserCommandResponse(result);
        }

        private SqlInsertedEvent CreateSqlInsertedEvent(InsertUserCommandRequest request, int result) =>
            new SqlInsertedEvent()
            {
                Email = request.Email,
                Nome = request.Nome,
                UserId = result
            };
    }
}
