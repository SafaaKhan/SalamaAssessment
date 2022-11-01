using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalamaAssessment.Data;
using SalamaAssessment_Models.Dtos;
using SalamaAssessment_Models.Models.ValidationModels;

namespace SalamaAssessmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Policies : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Policies(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postPolicyInfoDto"></param>
        /// <returns></returns>
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
