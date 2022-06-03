namespace TransferBGN.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TransferBGN.Core.Contracts;
    using TransferBGN.Core.Models.Transfer;
    using TransferBGN.Infrastructure.Data;

    public class TransferService : ITransferService
    {
        private readonly ApplicationDbContext db;

        public TransferService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TransferViewModel> All()
        {
            var allPo = db
                .PaymentOrders
                .Select(t => new TransferViewModel
                {
                    Id = t.Id,
                    OrderingBankName = t.OrderingBank.Name,
                    OrderingBankBranch = t.OrderingBank.Branch,
                    OrderingBankAddress = t.OrderingBank.Address,
                    DateOfSubmission = t.DateOfSubmission,
                    BeneficiaryAccountHolder = t.BeneficiaryAccountHolder.FullName,
                    BeneficiaryAccount = t.BeneficiaryAccount.IbanN,
                    BeneficiaryBic = t.BeneficiaryBank.BIC,
                    BeneficiaryBank = t.BeneficiaryBank.Name,
                    Amount = t.Amount,
                    ReasonForPayment = t.ReasonForPayment,
                    AdditionalComment = t.AdditionalComment,
                    OrderingAccountHolder = t.OrderingAccountHolder.FullName,
                    OrderingAccount = t.OrderingAccount.IbanN,
                    OrderingBic = t.OrderingBank.BIC,
                    PaymentSystem = t.PaymentSystem.Name,
                    DateOfPayment = t.DateOfPayment
                })
                .ToList();

            return allPo;
        }

        public TransferInputModel Create(TransferInputModel model)
        {
            throw new NotImplementedException();

            //return model;
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public TransferViewModel GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public TransferViewModel GetByIban(string iban)
        {
            throw new NotImplementedException();
        }

        public void Update(TransferInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
