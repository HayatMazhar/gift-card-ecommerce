using MediatR;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Responses;
using System.Collections.Generic;

namespace Bamboo.Application.Features.Product.Queries
{
    public class GetAllQuery : IRequest<Response<List<ProductVM>>>
    {
    }
}
