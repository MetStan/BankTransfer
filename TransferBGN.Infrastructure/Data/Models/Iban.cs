namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Iban
    {
        public Iban()
        {
            Id = Guid.NewGuid().ToString();
            OrderingAccountPaymentOrders = new HashSet<PaymentOrder>();
            BeneficiaryAccountPaymentOrders = new HashSet<PaymentOrder>();
            //OpenDate = DateTime.Now;
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }


        //^[a-zA-Z]{2}[0-9]{2}\s?[a-zA-Z0-9]{4}\s?[0-9]{4}\s?[0-9]{3}([a-zA-Z0-9]\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,3})?$        
        [Required]
        [MaxLength(22)]
        public string IbanN { get; set; }

        [MaxLength(13)]
        public decimal Balance { get; set; }

        //public DateTime OpenDate { get; set; }

        [Required]
        [MaxLength(36)]
        [ForeignKey(nameof(AccountHolder))]
        public string AccountHolderId { get; set; }
        public AccountHolder AccountHolder { get; set; }

        //public int CurrencyId { get; set; }

        //public virtual Currency? CurrencyCode { get; set; }

        [Required]
        [MaxLength(36)]
        public string BankId { get; set; }
        public Bank Bank { get; set; }


        [InverseProperty("OrderingAccount")]
        public ICollection<PaymentOrder> OrderingAccountPaymentOrders { get; set; }

        [InverseProperty("BeneficiaryAccount")]
        public ICollection<PaymentOrder> BeneficiaryAccountPaymentOrders { get; set; }
    }
}

