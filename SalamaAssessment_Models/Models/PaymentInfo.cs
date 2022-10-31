using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Models
{
    public class PaymentInfo
    {
        public string Id { get; set; }
        public string CardNumber{ get; set; }
        public string CVV { get; set; }
        public string ExpiryDate { get; set; }
        public string CardholderName { get; set; }
        public string QuoteInfoId { get; set; }

        public int QuoteInfoIdKey { get; set; }

        [ForeignKey("QuoteInfoIdKey")]
        public QuoteInfo QuoteInfo { get; set; }
        

    }
}
