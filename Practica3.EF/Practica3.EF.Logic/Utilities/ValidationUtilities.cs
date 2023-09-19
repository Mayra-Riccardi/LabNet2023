using System;
using System.Collections.Generic;

namespace Practica3.EF.Logic.Utilities
{
    internal class ValidationUtilities
    {
        public static void ThrowValidationErrors(List<string> errors)
        {
            string errorMessage = string.Join("\n", errors);
            throw new ArgumentException(errorMessage);
        }
    }
}
