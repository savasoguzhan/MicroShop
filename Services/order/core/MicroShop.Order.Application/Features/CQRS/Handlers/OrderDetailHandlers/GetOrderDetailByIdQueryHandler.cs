﻿using MicroShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId = values.OrderDetailId,
                ProdcutId=values.ProdcutId,
                OrderingId = values.OrderingId,
                ProdcutName = values.ProdcutName,
                ProductAmount = values.ProductAmount,
                ProductPrice = values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice

                
                
            };
        }
    }
}
