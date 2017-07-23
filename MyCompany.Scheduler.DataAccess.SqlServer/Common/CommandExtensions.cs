// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandExtensions.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The command extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.SqlServer.Common
{
    using System;
    using System.Data;

    /// <summary>
    /// The command extensions.
    /// </summary>
    public static class CommandExtensions
    {
        /// <summary>
        /// The add parameter.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="IDataParameter"/>.
        /// </returns>
        public static IDataParameter AddParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? DBNull.Value;
            command.Parameters.Add(parameter);
            return parameter;
        }
    }
}
