namespace TransferBGN.Infrastructure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AccountHolder
    {
        public AccountHolder()
        {
            Id = Guid.NewGuid().ToString();
           
            Ibans = new HashSet<Iban>();
            OrderingAccountHolderPaymentOrders = new HashSet<PaymentOrder>();
            BeneficiaryAccountHolderPaymentOrders = new HashSet<PaymentOrder>();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        [Required]
        [MaxLength(36)]
        public string FullName { get; set; }


        [InverseProperty("OrderingAccountHolder")]
        public ICollection<PaymentOrder> OrderingAccountHolderPaymentOrders { get; set; }


        [InverseProperty("BeneficiaryAccountHolder")]
        public ICollection<PaymentOrder> BeneficiaryAccountHolderPaymentOrders { get; set; }
        
        public ICollection<Iban> Ibans{ get; set; }
    }
}
