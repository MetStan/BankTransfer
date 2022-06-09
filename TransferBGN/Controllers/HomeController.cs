namespace TransferBGN.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TransferBGN.Core.Contracts;

    public class HomeController : Controller
    {
        private readonly ITransferService service;

        public HomeController(ITransferService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var latestTransfers = service.Latest();

            return View(latestTransfers);
        }

        public IActionResult Error()
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}