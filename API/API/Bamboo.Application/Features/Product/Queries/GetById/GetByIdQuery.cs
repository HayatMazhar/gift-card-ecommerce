using MediatR;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Responses;

namespace Bamboo.Application.Features.Product
{
    public class GetByIdQuery : IRequest<Response<ProductVM>>
    {
        public int Id { get; set; }
    }
}
