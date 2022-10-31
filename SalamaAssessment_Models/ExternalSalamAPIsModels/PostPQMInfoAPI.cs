using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ExternalSalamAPIsModels
{
    public class PostPQMInfoAPI
    {
        public string city { get; set; }
        public string dob { get; set; }//dateOnly or dataTime?
        public string gender { get; set; }
        public string marital_status { get; set; }
        public string vehicle_make { get; set; }
    }
}
