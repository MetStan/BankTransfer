namespace TransferBGN.Core.Models
{
    using System;

    public class TransferViewModel
    {
        public string Id { get; init; }

        public decimal Amount { get; init; }

        public string ReasonForPayment { get; init; }

        public string? AdditionalComment { get; init; }

        public string OrderingAccountHolder { get; init; }

        public string OrderingAccount { get; init; }

        public string OrderingBankName { get; init; }

        public string OrderingBankBranch { get; init; }

        public string OrderingBankAddress { get; init; }

        public string OrderingBic { get; init; }

        public string BeneficiaryAccountHolder { get; init; }

        public string BeneficiaryAccount { get; init; }

        public string BeneficiaryBank { get; init; }

        public string BeneficiaryBic { get; init; }

        public DateTime DateOfPayment { get; init; }

        public DateTime DateOfSubmission { get; init; }

        public string PaymentSystem { get; init; }

        public string FeeType { get; init; }
    }
}
