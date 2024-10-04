using MicroShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MicroShop.Order.Application.Interfaces;
using MicroShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                OrderingId = command.OrderingId,
                ProdcutId = command.ProdcutId,
                ProdcutName = command.ProdcutName,
                ProductAmount = command.ProductAmount,
                ProductPrice = command.ProductPrice,
                ProductTotalPrice = command.ProductTotalPrice,
            });
        }
    }
}
