namespace TransferBGN.Core.Models.Transfer
{
    public class TransferListViewModel
    {
        public string DateOfSubmission { get; init; }

        public string BeneficiaryAccountHolder { get; init; }

        public string BeneficiaryAccount { get; init; }

        public string BeneficiaryBank { get; init; }

        public decimal Amount { get; init; }

        public string ReasonForPayment { get; init; }

        public string AdditionalComment { get; init; }

        public string OrderingBank { get; set; }

        public string OrderingAccountHolder { get; init; }
        
        public string OrderingAccount { get; init; }

        public string CurrencyCode { get; init; }

        public string PaymentSystem { get; init; }

        public DateTime DateOfPayment { get; init; }
    }
}
