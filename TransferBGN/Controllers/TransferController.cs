namespace TransferBGN.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TransferBGN.Core.Contracts;
    using TransferBGN.Core.Models;
    using TransferBGN.Core.Models.Transfer;
    using TransferBGN.Infrastructure.Data;

    public class TransferController : Controller
    {
        private readonly ITransferService service;

        public TransferController(ITransferService service)
        {
            this.service = service;
        }

       
        public IActionResult Add()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Add(TransferInputModel po)
        {
            var newPo = service.Create(po);

            if (ModelState.IsValid == false)
            {
                return View(newPo);
            }

            var allTransfers = service.All();

            return RedirectToAction(nameof(All), allTransfers);
        }

        public IActionResult All()
        {
            var allTransfers = service.All();

            return View();
           // return View(allTransfers);
        }
    }
}
