using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalamaAssessment_Models.Models.ValidationModels
{
    public class ValidationFailedResult: ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
    {
        StatusCode = StatusCodes.Status200OK; //StatusCodes.Status400BadRequest
        }
}
}
