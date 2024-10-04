using MicroShop.Order.Application.Features.CQRS.Result.OrderDetailResult;
using MicroShop.Order.Application.Interfaces;
using MicroShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                ProdcutId = x.ProdcutId,
                ProdcutName = x.ProdcutName,
                ProductAmount = x.ProductAmount,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice= x.ProductTotalPrice,
            } ).ToList();
        }
    }
}
