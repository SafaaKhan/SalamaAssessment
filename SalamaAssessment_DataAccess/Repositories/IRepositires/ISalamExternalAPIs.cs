using SalamaAssessment_Models.ExternalSalamAPIsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_DataAccess.Repositories.IRepositires
{
    public interface ISalamExternalAPIs
    {
        //get premium: GET 
        Task<PremiumValue> GetPremium(PostPQMInfoAPI postPQMInfoAPI);

        //post payment info
        Task<ReturnedPaymentInfo> PostPaymentInfo(PostPaymentInfo postPaymentInfo);

        //post policy information to salama core system
        Task<ReturnPolicyNumber> PostInfoForPolicy(PostInfoForPolicy postInfoForPolicy);
    }
}
