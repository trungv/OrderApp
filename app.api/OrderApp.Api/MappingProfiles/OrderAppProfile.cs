using AutoMapper;
using OrderApp.Api.ViewModel;
using OrderApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Api.MappingProfiles
{
    public class OrderAppProfile : Profile
    {
        public OrderAppProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<OrderDetail, OrderDetailViewModel>();
            CreateMap<OrderDetailViewModel, OrderDetail>();

            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderViewModel, Order>();
        }
    }
}
