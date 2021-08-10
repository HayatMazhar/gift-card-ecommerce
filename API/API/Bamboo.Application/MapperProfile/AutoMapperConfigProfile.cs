using AutoMapper;
using Bamboo.Domain.Entities;
using Bamboo.Application.Features.Product.ViewModel;
using Product = Bamboo.Domain.Entities.Product;
using OrderVM = Bamboo.Application.Features.Order.ViewModel.OrderVM;
using Bamboo.Application.Features.Order.Commands;

namespace Bamboo.Application.MapperProfile
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<ProductVM, Product>().ReverseMap();
            CreateMap<OrderVM, Order>().ReverseMap();
            CreateMap<CreateOrderCommand, Order>().ReverseMap();
            CreateMap<OrderProductVM, OrderProduct>().ReverseMap();

        }
    }
}
