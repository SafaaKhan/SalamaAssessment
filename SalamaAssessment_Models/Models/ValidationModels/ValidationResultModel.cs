using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SalamaAssessment_Models.Models.ValidationModels
{
    public class ValidationResultModel
    {
        public ValidationError Error { get; }
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Error = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(x.ErrorMessage)))
                    .FirstOrDefault();
        }
    }
}
