namespace TransferBGN.Core.Models.Currency
{
    using System.ComponentModel.DataAnnotations;

    public class CurrencyInputModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"[A-Z]{3}")]
        public string CurrencyCode { get; set; }
    }
}
