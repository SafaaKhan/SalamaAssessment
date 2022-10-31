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
    public class QuoteInfoVM
    {

        [Required]
        [MinLength(3, ErrorMessage = "Customer Name must be at least 3 characters.")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        //[Range(9,11, ErrorMessage = "Customer National Id must be 10 digits")]
        [DisplayName("Customer National Id")]
        public int CustomerNationalId { get; set; }

        [Required]
        [DisplayName("City")]
        public City? City { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [DisplayName("Gender")]
        public Gender? Gender { get; set; }

        [Required]
        [DisplayName("Marital Status")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Required]
        [DisplayName("Vehicle Make")]
        public VehicleMake? VehicleMake { get; set; }
    }
}
