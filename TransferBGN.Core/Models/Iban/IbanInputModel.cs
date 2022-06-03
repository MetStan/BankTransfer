namespace TransferBGN.Core.Models.Iban
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TransferBGN.Infrastructure.Data.Models;

    public class IbanInputModel
    {
        public string Id { get; init; }


        //^[a-zA-Z]{2}[0-9]{2}\s?[a-zA-Z0-9]{4}\s?[0-9]{4}\s?[0-9]{3}([a-zA-Z0-9]\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,4}\s?[a-zA-Z0-9]{0,3})?$        
        [Required]
        [MaxLength(22)]
        [RegularExpression(@"^[Bb][Gg][0-9]{2}[a-zA-Z]{4}[0-9]{6}[a-zA-Z0-9]{8}$")]
        public string IbanN { get; init; }

        //[MaxLength(13)]
        //[Range(typeof(decimal), "0.01", "999999999999")]
        //public decimal Balance { get; init; }


        [Required]
        [MaxLength(36)]
        public string AccountHolderId { get; init; }
        public AccountHolder AccountHolder { get; init; }


        [Required]
        [MaxLength(36)]
        public string BankId { get; init; }
        public Bank Bank { get; init; }


        [Required]
        [MaxLength(36)]
        public string CurrencyId { get; init; }

        public Currency CurrencyCode { get; init; }
    }
}
