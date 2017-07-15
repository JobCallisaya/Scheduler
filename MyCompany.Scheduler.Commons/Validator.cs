// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Validator.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Validates common functionality
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Commons
{
    using System;

    /// <summary>
    /// Validates common functionality
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Validates if an argument is null.
        /// </summary>
        /// <param name="argument">The argument</param>
        /// <param name="parameterName">The parameter name for the argument</param>
        /// <exception cref="System.ArgumentNullException">When argument is null.</exception>
        public static void ValidateNullArgument(object argument, string parameterName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(parameterName, "The parameter should not be null");
            }
        }
    }
}
