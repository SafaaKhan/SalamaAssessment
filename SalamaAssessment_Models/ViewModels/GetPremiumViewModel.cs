using SalamaAssessment_Models.ExternalSalamAPIsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ViewModels
{
    public class GetPremiumViewModel
    {
        public DisplayQuoteInfoVM DQuoteInfoVM { get; set; }
        public PremiumValue PremiumValue { get; set; }
    }
}
