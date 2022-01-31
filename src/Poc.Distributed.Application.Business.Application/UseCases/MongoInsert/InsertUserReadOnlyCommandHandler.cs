using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Poc.Distributed.Application.Business.Application.UseCases.MongoInsert
{
    public class InsertUserReadOnlyCommandHandler : IRequestHandler<InsertUserReadOnlyCommandRequest, InsertUserReadOnlyCommandResponse>
    {
        public Task<InsertUserReadOnlyCommandResponse> Handle(InsertUserReadOnlyCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
