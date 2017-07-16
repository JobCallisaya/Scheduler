// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomExpression.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The custom expression.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess
{
    /// <summary>
    /// The custom expression.
    /// </summary>
    public class CustomExpression
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        public Operator Operator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }
}
