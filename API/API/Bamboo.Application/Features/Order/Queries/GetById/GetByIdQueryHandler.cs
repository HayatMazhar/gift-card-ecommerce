using AutoMapper;
using MediatR;
using Bamboo.Application.Features.Product.Queries;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using Bamboo.Application.Features.Order.ViewModel;

namespace Bamboo.Application.Features.Order.Queries.GetDepartmentDetail
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<OrderVM>>
    {
        private readonly IAsyncProductRepository _SectionRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IAsyncProductRepository departmentRepository, IMapper mapper)
        {
            _SectionRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<OrderVM>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<OrderVM>();
            var result = await _SectionRepository.GetByIdAsync(request.Id);

            var mappedResult = _mapper.Map<OrderVM>(result);
            response.Data = mappedResult;
            return response;
        }
    }
}
