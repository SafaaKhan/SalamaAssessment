using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Models
{
    public class PolicyInfo
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }

        public int PaymentInfoIdKey { get; set; }

        [ForeignKey("PaymentInfoIdKey")]
        public PaymentInfo PaymentInfo { get; set; }
    }
}
