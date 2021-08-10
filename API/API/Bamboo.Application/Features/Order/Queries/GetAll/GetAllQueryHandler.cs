using AutoMapper;
using MediatR;
using Bamboo.Application.Features.Product.ViewModel;
using Bamboo.Application.Infrastructure.Repository;
using Bamboo.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bamboo.Application.Features.Order.ViewModel;

namespace Bamboo.Application.Features.Order.Queries
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<List<OrderVM>>>
    {
        private readonly IAsyncProductRepository _SectionRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IAsyncProductRepository departmentRepository, IMapper mapper)
        {
            _SectionRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<OrderVM>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<List<OrderVM>>();
            var result = await _SectionRepository.GetAllAsync();
            var mappedResult = _mapper.Map<List<OrderVM>>(result);
            response.Data = mappedResult;
            
            return response;
        }



    }
}
