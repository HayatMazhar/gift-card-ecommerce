using AutoMapper;
using MediatR;
using Bamboo.Application.Exceptions;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Bamboo.Application.Features.Product.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IAsyncProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IAsyncProductRepository ProductRepository, IMapper mapper)
        {
            _ProductRepository = ProductRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<int>();
            var model = _mapper.Map<Domain.Entities.Product>(request);
            await _ProductRepository.AddAsync(model);
            response.Message = "Data added successfully";

            return response;
        }
    }
}
