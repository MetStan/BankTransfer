namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bank
    {
        public Bank()
        {
            Ibans = new HashSet<Iban>();
            OrderingBankPaymentOrders = new HashSet<PaymentOrder>();
            BeneficiaryBankPaymentOrders = new HashSet<PaymentOrder>();

            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string Branch { get; set; }

        //(@"[a-zA-Z]{4}[a-zA-Z]{2}[a-zA-Z0-9]{2}([a-zA-Z0-9]{3})?")
        //[A-Z]{6,6}[A-Z2-9][A-NP-Z0-9]([A-Z0-9]{3,3}){0,1}
        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[A-Z]{6}[A-Z0-9]{2}")]
        public string BIC { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        public ICollection<Iban> Ibans { get; set; }

        [InverseProperty("OrderingBank")]
        public ICollection<PaymentOrder> OrderingBankPaymentOrders { get; set; }

        [InverseProperty("BeneficiaryBank")]
        public ICollection<PaymentOrder> BeneficiaryBankPaymentOrders { get; set; }
    }
}
