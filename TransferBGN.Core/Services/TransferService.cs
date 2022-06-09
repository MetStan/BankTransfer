namespace TransferBGN.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TransferBGN.Core.Contracts;
    using TransferBGN.Core.Models.Transfer;
    using TransferBGN.Infrastructure.Data;
    using TransferBGN.Infrastructure.Data.Models;

    public class TransferService : ITransferService
    {
        private readonly ApplicationDbContext db;

        public TransferService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TransferViewModel> Latest()
        {
            var latestTransfers = db
                .PaymentOrders
                .OrderByDescending(x => x.DateOfSubmission)
                .Select(t => new TransferViewModel
                {
                    OrderingAccountHolder = t.OrderingAccountHolder.FullName,
                    OrderingAccount = t.OrderingAccount.IbanN,
                    OrderingBank = t.OrderingBank.Name,
                    Amount = t.Amount,
                    CurrencyCode = t.Currency.CurrencyCode,
                    ReasonForPayment = $"{t.ReasonForPayment} {t.AdditionalComment}",
                    BeneficiaryAccountHolder = t.BeneficiaryAccountHolder.FullName,
                    BeneficiaryAccount = t.BeneficiaryAccount.IbanN,
                    BeneficiaryBank = t.BeneficiaryBank.Name,
                    DateOfSubmission = t.DateOfSubmission,
                    DateOfPayment = t.DateOfPayment
                })
                .Take(10)
                .ToList();

            return latestTransfers;
        }


        public IEnumerable<TransferViewModel> All()
        {
            var allPo = db
                .PaymentOrders
                .Select(t => new TransferViewModel
                {
                    Id = t.Id,
                    OrderingBank = t.OrderingBank.Name,
                    OrderingBankBranch = t.OrderingBank.Branch,
                    OrderingBankAddress = t.OrderingBank.Address,
                    DateOfSubmission = t.DateOfSubmission,
                    BeneficiaryAccountHolder = t.BeneficiaryAccountHolder.FullName,
                    BeneficiaryAccount = t.BeneficiaryAccount.IbanN,
                    BeneficiaryBic = t.BeneficiaryBank.BIC,
                    BeneficiaryBank = t.BeneficiaryBank.Name,
                    Amount = t.Amount,
                    ReasonForPayment = $"{t.ReasonForPayment} {t.AdditionalComment}",
                    OrderingAccountHolder = t.OrderingAccountHolder.FullName,
                    OrderingAccount = t.OrderingAccount.IbanN,
                    OrderingBic = t.OrderingBank.BIC,
                    PaymentSystem = t.PaymentSystem.Name,
                    DateOfPayment = t.DateOfPayment
                })
                .OrderByDescending(t => t.DateOfSubmission)
                .ToList();

            return allPo;
        }

        public PaymentOrder Create(TransferInputModel model)
        {

            PaymentOrder newTransfer = new PaymentOrder
            {
                DateOfSubmission = DateTime.Today.ToLocalTime(),
                Amount = model.Amount,
                ReasonForPayment = model.ReasonForPayment,
                AdditionalComment = model.AdditionalComment,
                DateOfPayment = model.DateOfPayment,
            };
            bool isOrderingBank = db
                .Banks
                .Any(ob => ob.Name.ToUpper().Trim() == model.OrderingBank.ToUpper().Trim()
                 && ob.Branch.ToUpper().Trim() == model.OrderingBankBranch.ToUpper().Trim());

            bool isBeneficiaryBank = db
                .Banks
                .Any(bb => bb.Name.ToUpper().Trim() == model.BeneficiaryBank.ToUpper().Trim());


            if (isOrderingBank == false)
            {
                var newBank = new Bank
                {
                    Address = model.OrderingBankAddress,
                    Branch = model.OrderingBankBranch,
                    BIC = model.OrderingBic,
                    Name = model.OrderingBank,
                };

                db.Banks.Add(newBank);
            }

            if (isBeneficiaryBank == false)
            {
                var newBank = new Bank
                {
                    //Address = model.be,
                    Name = model.BeneficiaryBank,
                    BIC = model.BeneficiaryBic,
                    //Branch = model.
                };

                db.Banks.Add(newBank);
            }

            return newTransfer;
        }

        public void Update(TransferInputModel model)
        {
            throw new NotImplementedException();
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

        public bool IsBankExist(string bankName)
        {
            var result = db.Banks.Any(b => b.Name == bankName);

            return result;
        }

    }
}
