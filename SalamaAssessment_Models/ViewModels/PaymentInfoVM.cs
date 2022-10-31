using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ViewModels
{
    public class PaymentInfoVM
    {

        public string QuotationId { get; set; }
        public int QuotationIdKey { get; set; }

        [Required(ErrorMessage = "The Card Number field is required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Card Number must be 10 digits")]
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3})$", ErrorMessage = "CVV must be 3 digits")]
        [DisplayName("CVV")]
        public string CVV { get; set; }

        [Required]
        [DisplayName("Expiry Date")]
        public string ExpiryDate { get; set; }//4 char

        [Required]
        [MinLength(3, ErrorMessage = "Cardholder Name must be at least 3 characters.")]
        [DisplayName("Cardholder Name")]
        public string CardholderName { get; set; }
    }
}
