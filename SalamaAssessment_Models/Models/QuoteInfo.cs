using SalamaAssessment_Models.Models.SelectLists;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Models
{
    public class QuoteInfo
    {
        [Key]
        public int Id { get; set; }
        public string QuotationId { get; set; } 
        public string CustomerName { get; set; }=String.Empty;//???
        public string CustomerNationalId { get; set; }
        [Required]
        public City? City { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        [Required]
        public MaritalStatus? MaritalStatus { get; set; }
        [Required]
        public VehicleMake? VehicleMake { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

    }
}
