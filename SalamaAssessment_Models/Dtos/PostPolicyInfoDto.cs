using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Dtos
{
    public class PostPolicyInfoDto
    {
     
        [Required]
        [MinLength(3, ErrorMessage = "Policyholder Name must be at least 3 characters.")]
        public string PolicyHolderName { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "PolicyHolder Id must be 10 digits")]
        public string PolicyHolderId { get; set; }
    }
}
