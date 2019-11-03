using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderApp.Api.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }
        public CustomerViewModel CustomerViewModel { get; set; }

        public DateTime? OrderDate { get; set; }

        public string Status { get; set; }

        public List<OrderDetailViewModel> OrderDetailViewModelList { get; set; }

        public decimal? Total
        {
            get
            {
                if (OrderDetailViewModelList != null)
                    return OrderDetailViewModelList.Sum(r => r.Quantity * r.UnitPrice);
                return null;
            }
        }

        public decimal? TotalQuantity
        {
            get
            {
                if (OrderDetailViewModelList != null)
                    return OrderDetailViewModelList.Sum(r => r.Quantity);
                return null;
            }
        }
    }
}
