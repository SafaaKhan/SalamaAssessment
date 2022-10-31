using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ExternalSalamAPIsModels
{
    public class PostPaymentInfo
    {
        public string card_number { get; set; }
        public string cvv { get; set; }
        public string expiry_date { get; set; }
        public string cardholder_name { get; set; }
        public string quotation_id { get; set; }
    }
}
