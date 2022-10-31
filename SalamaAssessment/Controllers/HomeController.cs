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
            QuoteInfoVM quoteInfovm = new QuoteInfoVM();
           
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
                    city = quoteInfovm.City.ToString(),
                    dob = quoteInfovm.DateOfBirth?.ToString("dd-MM-yyyy"),
                    gender = quoteInfovm.Gender.ToString(),
                    marital_status = quoteInfovm.MaritalStatus.ToString(),
                    vehicle_make = quoteInfovm.VehicleMake.ToString(),
                };
                PremiumValue premiumValue = await _salamExternalAPIs.GetPremium(postPQMInfo);
                if (premiumValue.Premium == 0 || premiumValue==null)
                {
                    return View(quoteInfovm);//error mes
                }

                var getPremiumViewModel = new GetPremiumViewModel
                {
                    PremiumValue= premiumValue,
                    QuoteInfoVM=quoteInfovm
                };
                ViewBag.DateOfBirth = quoteInfovm.DateOfBirth?.ToString("dd-MM-yyyy");
                return View("GetPremium", getPremiumViewModel);
            }
            return View(quoteInfovm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyPolicy(GetPremiumViewModel getPremiumViewModel)
        {
            // add the QuoteInfo to db
            var quoteInfo = new QuoteInfo
            {
                CustomerName = getPremiumViewModel.QuoteInfoVM.CustomerName,
                CustomerNationalId = getPremiumViewModel.QuoteInfoVM.CustomerNationalId.ToString(),
                DateOfBirth = getPremiumViewModel.QuoteInfoVM.DateOfBirth,
                City = getPremiumViewModel.QuoteInfoVM.City,
                Gender = getPremiumViewModel.QuoteInfoVM.Gender,
                MaritalStatus = getPremiumViewModel.QuoteInfoVM.MaritalStatus,
                VehicleMake = getPremiumViewModel.QuoteInfoVM.VehicleMake,
                QuotationId=""
            };
            _db.QuoteInfo.Add(quoteInfo);
            await _db.SaveChangesAsync();

            quoteInfo.QuotationId = (quoteInfo.Id + 50200).ToString();
            await _db.SaveChangesAsync();

            //create payment model- pass it to the view
            var paymentInfoVM = new PaymentInfoVM();
            paymentInfoVM.QuotationId=quoteInfo.QuotationId;
            paymentInfoVM.QuotationIdKey = quoteInfo.Id;
            return View("BuyPolicy", paymentInfoVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PurchasePolicy(PaymentInfoVM paymentInfoVM)
        {
            if (ModelState.IsValid)
            {
                // post the payment in to spg api
                PostPaymentInfo postPaymentInfo = new PostPaymentInfo
                {
                    cardholder_name = paymentInfoVM.CardholderName,
                    card_number = paymentInfoVM.CardNumber,
                    cvv = paymentInfoVM.CVV,
                    expiry_date = paymentInfoVM.ExpiryDate.Replace(@"/", string.Empty),
                    quotation_id = paymentInfoVM.QuotationId
                };

                ReturnedPaymentInfo returnedPaymentInfo = await _salamExternalAPIs.PostPaymentInfo(postPaymentInfo);
                if ( returnedPaymentInfo == null) //?
                {
                    return View("BuyPolicy",paymentInfoVM);//error mes (fail to process payment )
                }

                //save payment info to the database
                PaymentInfo paymentInfo = new PaymentInfo
                {
                    Id= Guid.NewGuid().ToString(),
                    CardholderName= paymentInfoVM.CardholderName,
                    CardNumber=paymentInfoVM.CardNumber,
                    CVV= paymentInfoVM.CVV,
                    ExpiryDate=paymentInfoVM.ExpiryDate,
                    QuoteInfoId= paymentInfoVM.QuotationId,
                    QuoteInfoIdKey= paymentInfoVM.QuotationIdKey
                };
                _db.PaymentInfo.Add(paymentInfo);
                await _db.SaveChangesAsync();

                //Push Policy Information to SALAMA Core System (IssuePolicy)
                PushPolicyInfoToSCoreSys();
                return View("PolicyDetails");
            }
            return View("BuyPolicy",paymentInfoVM);
        }

        private IActionResult PushPolicyInfoToSCoreSys()
        {
            //must return the model not view
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}