using AutoMapper;
using MediatR;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Bamboo.Application.Features.Order.Commands;

namespace Bamboo.Application.Features.Product.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<int>>
    {
        private readonly IAsyncOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IAsyncOrderRepository repository, IMapper mapper)
        {
            _orderRepository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<int>();
            var model = _mapper.Map<Domain.Entities.Order>(request);
            
            await _orderRepository.AddAsync(model);
            response.Message = "Data added successfully";

            return response;
        }
    }
}
