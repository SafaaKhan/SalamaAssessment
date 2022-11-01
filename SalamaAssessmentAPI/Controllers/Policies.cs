using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalamaAssessment.Data;
using SalamaAssessment_Models.Dtos;
using SalamaAssessment_Models.Models.ValidationModels;

namespace SalamaAssessmentAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class Policies : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Policies(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        ///  Get policy information from salama web app / version no. 1
        /// </summary>
        ///<remarks>
        ///   Sample request: 
        /// 
        ///     POST api/Policies
        ///  {
        ///"policyHolderName": "Test Policy Api",
        ///"policyHolderId": "1000000012"
        ///  }
        ///</remarks>
        /// <param name="postPolicyInfoDto">Please, check the end of the web page for the model info(PostPolicyInfoDto)</param>
        /// <returns></returns>
        /// <response code="200">
        ///    For successful response:
        ///     {
        /// "status": true,
        /// "getPolicyDetailsDto": {
        ///  "policyHolderName": "Test Policy Api",
        ///  "quotationId": "502000000093",
        ///  "city": "Jeddah",
        ///  "dateOfBirth": "05-11-2022",
        ///  "gender": "Female",
        ///  "maritalStatus": "Married",
        ///  "vehicleMake": "BMW",
        ///  "policyNumber": "90200000009536"
        ///  }
        /// 
        /// </response>
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> GetPolicy(PostPolicyInfoDto postPolicyInfoDto)
        {
            var paymentInfo=  await _db.PaymentInfo.Include(x=>x.QuoteInfo).Include(x=>x.PolicyInfo).
                FirstOrDefaultAsync(x=>x.CardholderId ==
                postPolicyInfoDto.PolicyHolderId);

            if(paymentInfo == null)
            {
                return Ok(
                    new
                    {
                       status=false,
                       message= "The policy was not found with policyholder Id: " + postPolicyInfoDto.PolicyHolderId
                    }
                );
            }

            GetPolicyDetailsDto getPolicyDetailsDto = new GetPolicyDetailsDto
            {
                PolicyHolderName = paymentInfo.CardholderName,
                QuotationId=paymentInfo.QuoteInfoId,
                City=paymentInfo.QuoteInfo.City.ToString(),
                DateOfBirth= paymentInfo.QuoteInfo.DateOfBirth?.ToString("dd-MM-yyyy"),
                Gender= paymentInfo.QuoteInfo.Gender.ToString(),
                MaritalStatus= paymentInfo.QuoteInfo.MaritalStatus.ToString(),
                VehicleMake= paymentInfo.QuoteInfo.VehicleMake.ToString(),
                PolicyNumber= paymentInfo.PolicyInfo.PolicyNumber
            };

            return Ok(new {
                status = true,
                getPolicyDetailsDto });
        }
    }
}
