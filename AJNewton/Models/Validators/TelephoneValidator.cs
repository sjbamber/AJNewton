using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AJNewton.Models.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TelephoneAttribute : RegularExpressionAttribute, IClientValidatable
    {
        public TelephoneAttribute()
            : base(@"^\+?[0-9]{0,2}\(?[0-9]+ ?\)?[0-9 ]*$")
        {
            ErrorMessage = "The telephone number is not valid";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new TelephoneValidationRule(this.ErrorMessage, this.Pattern);
            yield return rule;
        }
    }

    public class TelephoneValidationRule : ModelClientValidationRule
    {
        public TelephoneValidationRule(string errorMessage, string pattern)
        {
            ErrorMessage = errorMessage;
            ValidationType = "regex";
            ValidationParameters.Add("pattern", pattern);
        }
    }
}