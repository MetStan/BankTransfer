namespace TransferBGN.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TransferBGN.Core.Contracts;
    using TransferBGN.Core.Models;
    using TransferBGN.Infrastructure.Data;

    public class TransferController : Controller
    {
        private readonly ITransferService service;

        public TransferController(ITransferService service)
        {
            this.service = service;
        }

        //[HttpPost]
        public IActionResult Add()
        {
            //var newPo = service.Create(po);



            return View();
        }

        public IActionResult All()
        {
            var allTransfers = service.All();

            return View(allTransfers);
        }
    }
}
