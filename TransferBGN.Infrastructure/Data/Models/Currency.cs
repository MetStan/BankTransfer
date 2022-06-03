namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Currency
    {
        public Currency()
        {
            Id = Guid.NewGuid().ToString();

            this.PaymentOrders = new HashSet<PaymentOrder>();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        public ICollection<PaymentOrder> PaymentOrders { get; set; }
    }
}
