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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
           
            values.OrderingId = command.OrderingId;
            values.ProductPrice = command.ProductPrice;
            values.ProductTotalPrice = command.ProductTotalPrice;
            values.ProdcutId = command.ProdcutId;
            values.ProdcutName= command.ProdcutName;
            values.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(values);


        }
    }
}
