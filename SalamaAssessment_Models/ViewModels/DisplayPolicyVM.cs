using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ViewModels
{
    public class DisplayPolicyVM
    {
        public DisplayQuoteInfoVM displayQuoteInfoVM { get; set; }
       
        [DisplayName("PolicyHolder Id")]
        public string PolicyHolderId { get; set; }

        [DisplayName("Policy Number")]
        public string PolicyNumber { get; set; }
       
    }
}
