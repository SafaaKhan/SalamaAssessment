using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using SalamaAssessment_DataAccess.Repositories.IRepositires;
using SalamaAssessment_Models.ExternalSalamAPIsModels;
using SalamaAssessment_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_DataAccess.Repositories
{
    public class SalamaExternalAPIs : ISalamExternalAPIs
    {
        private readonly ILogger<PostPQMInfoAPI> _logger;

        public SalamaExternalAPIs(ILogger<PostPQMInfoAPI> logger)
        {
            _logger = logger;
        }
        public async Task<PremiumValue> GetPremium(PostPQMInfoAPI postPQMInfoAPI)
        {
            var client = new RestClient(WC.SalamaURL + "pqm");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(postPQMInfoAPI);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                    var content = JsonConvert.DeserializeObject<PremiumValue>(response.Content);
                    _logger.LogInformation(response.Content);

                    return content;
            }

            _logger.LogInformation(response.Content);

            return null;
        }

        public async Task<ReturnedPaymentInfo> PostPaymentInfo(PostPaymentInfo postPaymentInfo)
        {
            var client = new RestClient(WC.SalamaURL + "spg");
            var request = new RestRequest();
            request.Method = Method.Post;

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(postPaymentInfo);

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                try
                {
                    var content = JsonConvert.DeserializeObject<ReturnedPaymentInfo>(response.Content);
                    if (content.status == true)
                    {
                        _logger.LogInformation(response.Content);
                        return content;
                    }
                    _logger.LogInformation(response.Content);
                    return null;
                }
                catch
                {
                    _logger.LogInformation(response.Content);
                    return null;
                }
                
            }

            _logger.LogInformation(response.Content);
            return null;
        }
    }
}

