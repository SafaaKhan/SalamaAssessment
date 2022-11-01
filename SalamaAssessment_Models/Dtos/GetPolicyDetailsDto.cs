using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Dtos
{
    public class GetPolicyDetailsDto
    {
        public string PolicyHolderName { get; set; }

        public string QuotationId { get; set; }

        public string City { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string VehicleMake { get; set; }

        public string PolicyNumber { get; set; }

    }
}
