using AutoMapper;
using OrderApp.Api.Common;
using OrderApp.Api.ViewModel;
using OrderApp.Core.Entities;
using OrderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp.Api.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderServices(IBaseRepository<Order> orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool Add(OrderViewModel value)
        {
            // This have to use UnitOfWork
            Order order = _mapper.Map<Order>(value);

            // Save order
            _orderRepository.Add(order);

            return true;
        }

        public OrderViewModel Approve(int id)
        {
            var order = _orderRepository.GetByFilter(r => r.Id == id).FirstOrDefault();
            order.Status = Constants.Status.Approved;
            _orderRepository.Update(order);
            var orderViewModel = _mapper.Map<OrderViewModel>(order);

            return orderViewModel;
        }

        public List<OrderViewModel> GetAllOrder()
        {
            List<OrderViewModel> orderViewModelList = new List<OrderViewModel>();

            var orderList = _orderRepository.GetAll;
            orderViewModelList = _mapper.Map<List<OrderViewModel>>(orderList);

            return orderViewModelList;
        }

        public OrderViewModel GetOrderById(int id)
        {
            OrderViewModel orderViewModel = new OrderViewModel();

            var order = _orderRepository.GetByFilter(r => r.Id == id).FirstOrDefault();
            orderViewModel = _mapper.Map<OrderViewModel>(order);

            return orderViewModel;
        }

        public ProductViewModel GetProducts()
        {
            throw new NotImplementedException();
        }

        public OrderViewModel Reject(int id)
        {
            var order = _orderRepository.GetByFilter(r => r.Id == id).FirstOrDefault();
            order.Status = Constants.Status.Rejected;
            _orderRepository.Update(order);
            var orderViewModel = _mapper.Map<OrderViewModel>(order);

            return orderViewModel;
        }
    }
}
