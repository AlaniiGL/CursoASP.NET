using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success 
                : new ValidationResult("Se debe de tener al menos 18 años para tener acceso a una membresía de este tipo.");
        }
    }
} 