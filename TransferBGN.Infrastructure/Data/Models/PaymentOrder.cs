namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PaymentOrder
    {
        public PaymentOrder(string id)
        {
            Id = Guid.NewGuid().ToString();
            DateOfSubmission = DateTime.Now;
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [MaxLength(35)]
        public string ReasonForPayment { get; set; }


        [MaxLength(35)]
        public string? AdditionalComment { get; set; }

        [Required]
        [ForeignKey(nameof(OrderingAccountHolder))]
        [MaxLength(36)]
        public string OrderingAccountHolderId { get; set; }
        public AccountHolder? OrderingAccountHolder { get; set; }

        [Required]
        [ForeignKey(nameof(OrderingAccount))]
        [MaxLength(36)]
        public string OrderingAccountId { get; set; }
        public Iban OrderingAccount { get; set; }

        [Required]
        [ForeignKey(nameof(OrderingBank))]
        [MaxLength(36)]
        public string OrderingBankId { get; set; }
        public virtual Bank? OrderingBank { get; set; }

        [Required]
        [ForeignKey(nameof(BeneficiaryAccountHolder))]
        [MaxLength(36)]
        public string BeneficiaryAccountHolderId { get; set; }
        public AccountHolder? BeneficiaryAccountHolder { get; set; }

        [Required]
        [ForeignKey(nameof(BeneficiaryAccount))]
        [MaxLength(36)]
        public string BeneficiaryAccountId { get; set; }
        public Iban? BeneficiaryAccount { get; set; }


        [Required]
        [ForeignKey(nameof(BeneficiaryBank))]
        [MaxLength(36)]
        public string BeneficiaryBankId { get; set; }
        public Bank BeneficiaryBank { get; set; }

        public DateTime DateOfPayment { get; set; }

        public DateTime DateOfSubmission { get; set; }


        [Required]
        [ForeignKey(nameof(PaymentSystem))]
        [MaxLength(36)]
        public string PaymentSystemId { get; set; }
        public PaymentSystem PaymentSystem { get; set; }


        [ForeignKey(nameof(FeeType))]
        [MaxLength(36)]
        public string FeeTypeId { get; set; }
        public FeeType? FeeType { get; set; }



    }
}
