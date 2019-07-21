using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderApp.Core.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public DateTime? OrderDate { get; set; }

        public string Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetailList { get; set; }
    }
}
