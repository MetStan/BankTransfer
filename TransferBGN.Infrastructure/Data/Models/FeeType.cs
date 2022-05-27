namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FeeType
    {
        public FeeType()
        {
            this.PaymentOrders = new HashSet<PaymentOrder>();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public ICollection<PaymentOrder> PaymentOrders { get; set; }
    }
}
