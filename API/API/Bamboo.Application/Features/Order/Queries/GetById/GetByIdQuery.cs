using MediatR;
using Bamboo.Application.Responses;
using Bamboo.Application.Features.Order.ViewModel;

namespace Bamboo.Application.Features.Order.Queries
{
    public class GetByIdQuery : IRequest<Response<OrderVM>>
    {
        public int Id { get; set; }
    }
}
