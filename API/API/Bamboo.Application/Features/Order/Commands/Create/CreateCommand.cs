using MediatR;
using Bamboo.Application.Responses;
using System;
using System.Collections.Generic;

namespace Bamboo.Application.Features.Order.Commands
{
    public class CreateOrderCommand :  IRequest<Response<int>>
    {
        public string RequestID { get; set; }
        public string AccountId { get; set; }
        public List<Product.ViewModel.OrderProductVM> Products { get; set; } = new List<Product.ViewModel.OrderProductVM>();
    }
}
