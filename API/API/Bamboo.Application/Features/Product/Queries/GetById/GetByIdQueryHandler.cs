using AutoMapper;
using MediatR;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Bamboo.Application.Features.Product.Queries
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<ProductVM>>
    {
        private readonly IAsyncProductRepository _ProductRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IAsyncProductRepository departmentRepository, IMapper mapper)
        {
            _ProductRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<ProductVM>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<ProductVM>();
            var result = await _ProductRepository.GetByIdAsync(request.Id);

            var mappedResult = _mapper.Map<ProductVM>(result);
            response.Data = mappedResult;
            return response;
        }
    }
}
