using MediatR;
using MicroShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroShop.Order.Application.Interfaces;
using MicroShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommands>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });
        }
    }
}
