using MediatR;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Responses;
using System.Collections.Generic;
using Bamboo.Application.Features.Order.ViewModel;

namespace Bamboo.Application.Features.Order.Queries
{
    public class GetAllQuery : IRequest<Response<List<OrderVM>>>
    {
    }
}
