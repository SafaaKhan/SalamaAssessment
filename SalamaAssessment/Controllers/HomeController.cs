using Microsoft.AspNetCore.Mvc;
using SalamaAssessment.Data;
using SalamaAssessment.Models;
using SalamaAssessment_DataAccess.Repositories.IRepositires;
using SalamaAssessment_Models.ExternalSalamAPIsModels;
using SalamaAssessment_Models.Models;
using SalamaAssessment_Models.Models.SelectLists;
using SalamaAssessment_Models.ViewModels;
using System.Diagnostics;

namespace SalamaAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISalamExternalAPIs _salamExternalAPIs;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, 
            ISalamExternalAPIs salamExternalAPIs,
            ApplicationDbContext db)
        {
            _logger = logger;
            _salamExternalAPIs = salamExternalAPIs;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            QuoteInfoVM quoteInfovm = new QuoteInfoVM();//viewModel+validation
           
            return View(quoteInfovm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(QuoteInfoVM quoteInfovm)
        {
            if (ModelState.IsValid)
            {
                var postPQMInfo = new PostPQMInfoAPI
                {
                    city = "",
                    dob = quoteInfovm.DateOfBirth?.ToString("dd-MM-yyyy"),
                    gender = quoteInfovm.Gender.ToString(),
                    marital_status = quoteInfovm.MaritalStatus.ToString(),
                    vehicle_make = quoteInfovm.VehicleMake.ToString(),
                };
                PremiumValue premiumValue = await _salamExternalAPIs.GetPremium(postPQMInfo);
                if (premiumValue.Premium == 0 || premiumValue==null)
                {
                    return View(quoteInfovm);
                }

                var getPremiumViewModel = new GetPremiumViewModel
                {
                    DQuoteInfoVM=new DisplayQuoteInfoVM
                    {
                        CustomerName=quoteInfovm.CustomerName,
                        CustomerNationalId=quoteInfovm.CustomerNationalId,
                        City=quoteInfovm.City,
                        DateOfBirth= quoteInfovm.DateOfBirth?.ToString("dd-MM-yyyy"),
                        Gender=quoteInfovm.Gender,
                        MaritalStatus=quoteInfovm.MaritalStatus,
                        VehicleMake=quoteInfovm.VehicleMake
                    },
                    PremiumValue= premiumValue
                };
                return View("GetPremium", getPremiumViewModel);
            }
            return View(quoteInfovm);
        }

        

        public IActionResult Privacy()
        {
        //    var qoutInfo = new QuoteInfo
        //    {
        //        CustomerName = quoteInfovm.CustomerName,
        //        CustomerNationalId = quoteInfovm.CustomerNationalId.ToString(),
        //        DateOfBirth = quoteInfovm.DateOfBirth,//change form
        //        City = quoteInfovm.City,
        //        Gender = quoteInfovm.Gender,
        //        MaritalStatus = quoteInfovm.MaritalStatus,
        //        VehicleMake = quoteInfovm.VehicleMake
        //    };
        //    _db.quoteInfo.Add(qoutInfo);
        //    await _db.SaveChangesAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}