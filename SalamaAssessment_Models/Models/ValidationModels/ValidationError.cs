using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalamaAssessment_Models.Models.ValidationModels
{
    public class ValidationError
    {
        public string Message { get; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
