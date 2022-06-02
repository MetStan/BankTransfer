namespace TransferBGN.Infrastructure.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentOrder
    {
        public PaymentOrder(string id)
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [MaxLength(36)]
        public string Id { get; set; }


        [Required]
        [MaxLength(36)]
        [ForeignKey(nameof(OrderingBank))]
        public string OrderingBankId { get; set; }
        public virtual Bank OrderingBank { get; set; }


        [MaxLength(13)]
        public decimal Amount { get; set; }


        [Required]
        [MaxLength(36)]
        public string ReasonForPayment { get; set; }


        [MaxLength(36)]
        public string? AdditionalComment { get; set; }


        [Required]
        [ForeignKey(nameof(OrderingAccountHolder))]
        [MaxLength(36)]
        public string OrderingAccountHolderId { get; set; }
        public AccountHolder OrderingAccountHolder { get; set; }


        [Required]
        [ForeignKey(nameof(OrderingAccount))]
        [MaxLength(22)]
        public string OrderingAccountId { get; set; }
        public Iban OrderingAccount { get; set; }


        [Required]
        [ForeignKey(nameof(BeneficiaryAccountHolder))]
        [MaxLength(36)]
        public string BeneficiaryAccountHolderId { get; set; }
        public AccountHolder BeneficiaryAccountHolder { get; set; }


        [Required]
        [ForeignKey(nameof(BeneficiaryAccount))]
        [MaxLength(22)]
        public string BeneficiaryAccountId { get; set; }
        public Iban BeneficiaryAccount { get; set; }


        [Required]
        [ForeignKey(nameof(BeneficiaryBank))]
        [MaxLength(36)]
        public string BeneficiaryBankId { get; set; }
        public Bank BeneficiaryBank { get; set; }


        public DateTime DateOfPayment { get; set; }


        public DateTime DateOfSubmission { get; set; }


        [Required]
        [ForeignKey(nameof(PaymentSystem))]
        [MaxLength(10)]
        public string PaymentSystemId { get; set; }
        public PaymentSystem PaymentSystem { get; set; }


        [ForeignKey(nameof(FeeType))]
        [MaxLength(3)]
        public string FeeTypeId { get; set; }
        public FeeType? FeeType { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
