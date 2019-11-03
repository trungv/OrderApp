using System;

namespace OrderApp.Api.ViewModel
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int? OrderId { get; set; }
        //public virtual OrderViewModel OrderViewModel { get; set; }

        public int? ProductId { get; set; }
        public virtual ProductViewModel ProductViewModel { get; set; }

        public decimal UnitPrice { get; set; }

        public Int16 Quantity { get; set; }

        public decimal? Total
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
