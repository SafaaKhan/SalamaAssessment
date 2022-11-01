using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ExternalSalamAPIsModels
{
    public class ReturnPolicyNumber
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string policy_number { get; set; }
    }
}
