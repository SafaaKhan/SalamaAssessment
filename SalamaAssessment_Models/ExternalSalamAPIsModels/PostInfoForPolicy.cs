using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ExternalSalamAPIsModels
{
    public class PostInfoForPolicy
    {
        public string policy_holder_name { get; set; }
        public string quotation_id { get; set; }
        public string policy_holder_id { get; set; }
        public string city { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string marital_status { get; set; }
        public string vehicle_make { get; set; }

    }
}
