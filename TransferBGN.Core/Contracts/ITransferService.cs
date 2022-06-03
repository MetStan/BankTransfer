namespace TransferBGN.Core.Contracts
{
    using System.Collections.Generic;
    using TransferBGN.Core.Models.Transfer;

    public interface ITransferService
    {
        TransferInputModel Create(TransferInputModel model);

        void Update(TransferInputModel model);

        IEnumerable<TransferViewModel> All();

        void Delete(string id);

        TransferViewModel GetByIban(string iban);

        TransferViewModel GetByDate(DateTime date);
    }
}
