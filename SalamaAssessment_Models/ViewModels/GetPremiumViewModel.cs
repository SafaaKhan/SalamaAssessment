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
        public QuoteInfoVM QuoteInfoVM { get; set; }
        public PremiumValue PremiumValue { get; set; }
    }
}
