namespace TransferBGN.Core.Models.Transfer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransferInputModel
    {
        [Required]
        [MaxLength(36)]
        public string OrderingBank { get; set; }

        [Required]
        [MaxLength(36)]
        public string OrderingBankBranch { get; set; }


        [Required]
        [MaxLength(36)]
        public string OrderingBankAddress { get; set; }

        public DateTime DateOfSubmission { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(36)]
        public string BeneficiaryAccountHolder { get; set; }


        [Required]
        [MaxLength(22)]
        [RegularExpression(@"^[Bb][Gg][0-9]{2}[a-zA-Z]{4}[0-9]{6}[a-zA-Z0-9]{8}$")]//BG\d{2}[A-Z]{4}\d{4}\d{2}[a-zA-Z0-9]{8}
        public string BeneficiaryAccount { get; set; }


        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[A-Z]{6}[A-Z0-9]{2}")]
        public string BeneficiaryBic { get; set; }


        [Required]
        [MaxLength(36)]
        public string BeneficiaryBank { get; set; }


        [Range(typeof(decimal), "0.01", "999999999999")]
        public decimal Amount { get; set; }


        [Required]
        [MaxLength(36)]
        public string ReasonForPayment { get; set; }


        [MaxLength(36)]
        public string? AdditionalComment { get; set; }


        [Required]
        [MaxLength(36)]
        public string OrderingAccountHolder { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(22)]
        [RegularExpression(@"^[Bb][Gg][0-9]{2}[a-zA-Z]{4}[0-9]{6}[a-zA-Z0-9]{8}$")]
        public string OrderingAccount { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[A-Z]{6}[A-Z0-9]{2}")]
        public string OrderingBic { get; set; }

        [Required]
        [MaxLength(10)]
        public string PaymentSystem { get; set; } = "Бисера";


        [MaxLength(3)]
        public string FeeType { get; set; } = "002";

        public DateTime DateOfPayment { get; set; }

        //public bool IsDeleted { get; set; } = false;
    }
}
