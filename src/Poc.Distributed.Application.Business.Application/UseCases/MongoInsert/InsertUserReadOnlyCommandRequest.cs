using MediatR;
using Poc.Distributed.Application.Business.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poc.Distributed.Application.Business.Application.UseCases.MongoInsert
{
    public class InsertUserReadOnlyCommandRequest : IRequest<InsertUserReadOnlyCommandResponse>
    {
    }
}
