using OrderApp.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Api.Services
{
    public interface IOrderServices
    {
        List<OrderViewModel> GetAllOrder();
        OrderViewModel GetOrderById(int id);
        OrderViewModel Approve(int id);
        OrderViewModel Reject(int id);
        ProductViewModel GetProducts();
        bool Add(OrderViewModel value);
    }
}
