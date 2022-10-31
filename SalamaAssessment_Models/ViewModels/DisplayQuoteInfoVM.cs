using SalamaAssessment_Models.Models.SelectLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.ViewModels
{
    public class DisplayQuoteInfoVM
    {

        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Customer National Id")]
        public int CustomerNationalId { get; set; }

        [DisplayName("City")]
        public City? City { get; set; }

        [DisplayName("Date of Birth")]
        public string DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public Gender? Gender { get; set; }

        [DisplayName("Marital Status")]
        public MaritalStatus? MaritalStatus { get; set; }

        [DisplayName("Vehicle Make")]
        public VehicleMake? VehicleMake { get; set; }
    }
}
