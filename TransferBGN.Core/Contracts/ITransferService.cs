namespace TransferBGN.Core.Contracts
{
    using System.Collections.Generic;
    using TransferBGN.Core.Models.Transfer;
    using TransferBGN.Infrastructure.Data.Models;

    public interface ITransferService
    {
        PaymentOrder Create(TransferInputModel model);

        IEnumerable<TransferViewModel> Latest();

        IEnumerable<TransferViewModel> All();
        
        void Update(TransferInputModel model);


        void Delete(string id);

        TransferViewModel GetByIban(string iban);

        TransferViewModel GetByDate(DateTime date);
    }
}
