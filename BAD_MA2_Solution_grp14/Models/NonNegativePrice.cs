using System;
using System.ComponentModel.DataAnnotations;

public class NoneNegativeAttribute : ValidationAttribute
{
    public NoneNegativeAttribute() 
    {
        // Default error message
        this.ErrorMessage = "Price must be a non-negative value.";
    }

    public override bool IsValid(object value)
    {
        if (value is decimal decimalValue)
        {
            return decimalValue >= 0; // Ensure the price is not negative
        }
        return false;
    }
}
