// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbConnectionFactory.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The db connection factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.SqlServer
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// The DB connection factory.
    /// </summary>
    public class DbConnectionFactory : IDisposable
    {
        /// <summary>
        /// The connection.
        /// </summary>
        private IDbConnection connection;

        /// <summary>
        /// The create connection.
        /// </summary>
        /// <param name="connectionSettings">The connection settings.</param>
        /// <returns>The <see cref="IDbConnection"/>.</returns>
        /// <exception cref="ConfigurationErrorsException"></exception>
        public IDbConnection CreateConnection(ConnectionStringSettings connectionSettings)
        {
            var providerFactory = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
            this.connection = providerFactory.CreateConnection();

            if (this.connection == null)
            {
                throw new ConfigurationErrorsException(
                    string.Format(
                        "Failed to create a connection using the connection string named '{0}' in app/web.config.",
                        connectionSettings.Name));
            }

            this.connection.ConnectionString = connectionSettings.ConnectionString;
            this.connection.Open();
            return this.connection;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.connection.Dispose();
        }
    }
}
