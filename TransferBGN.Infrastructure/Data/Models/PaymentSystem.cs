namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PaymentSystem
    {
        public PaymentSystem()
        {
            Id = Guid.NewGuid().ToString();
            PaymentOrders = new HashSet<PaymentOrder>();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public ICollection<PaymentOrder> PaymentOrders { get; set; }
    }
}
