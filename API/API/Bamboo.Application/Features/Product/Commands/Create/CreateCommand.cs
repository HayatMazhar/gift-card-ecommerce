using MediatR;
using Bamboo.Application.Responses;

namespace Bamboo.Application.Features.Product.Commands
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
    }
}
