﻿namespace TransferBGN.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TransferInputModel
    {
        [Required]
        [MaxLength(36)]
        public string OrderingBankName { get; set; }

        [Required]
        [MaxLength(36)]
        public string OrderingBankBranch { get; set; }


        [Required]
        [MaxLength(36)]
        public string OrderingBankAddress { get; set; }

        public DateTime DateOfSubmission { get; set; } = DateTime.Now;

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
        [MaxLength(22)]
        [RegularExpression(@"^[Bb][Gg][0-9]{2}[a-zA-Z]{4}[0-9]{6}[a-zA-Z0-9]{8}$")]
        public string OrderingAccount { get; set; }

        [Required]
        [MaxLength(11)]
        [RegularExpression(@"[A-Z]{6}[A-Z0-9]{2}")]
        public string OrderingBic { get; set; }

        [Required]
        [MaxLength(10)]
        public string PaymentSystem { get; set; }


        //[MaxLength(3)]
        //public string FeeType { get; set; }

        public DateTime DateOfPayment { get; set; }


        public bool IsDeleted { get; set; } = false;
    }
}
