using OrderApp.Core.Entities;
using OrderApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Api.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderServices(IBaseRepository<Order> orderRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }
        public void GetAll()
        {
            var x = _orderRepository.GetAll.ToList();
        }
    }
}
