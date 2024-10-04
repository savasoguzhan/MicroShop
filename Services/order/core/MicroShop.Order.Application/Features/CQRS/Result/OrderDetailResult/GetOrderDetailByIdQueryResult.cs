﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroShop.Order.Application.Features.CQRS.Result.OrderDetailResult
{
    public class GetOrderDetailByIdQueryResult
    {
        public int OrderDetailId { get; set; }

        public string ProdcutId { get; set; }

        public string ProdcutName { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductAmount { get; set; }

        public decimal ProductTotalPrice { get; set; }

        public int OrderingId { get; set; }
    }
}
