// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdoUnitOfWork.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the AdoUnitOfWork type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The ado unit of work.
    /// </summary>
    public class AdoUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The own connection.
        /// </summary>
        private readonly bool ownConnection;

        /// <summary>
        /// The connection.
        /// </summary>
        private IDbConnection connection;

        /// <summary>
        /// The transaction.
        /// </summary>
        private IDbTransaction transaction;

        /// <summary>
        /// Dictionary of repositories managed by this unit of work.
        /// </summary>
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoUnitOfWork"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public AdoUnitOfWork(IDbConnection connection)
            : this(connection, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoUnitOfWork"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="ownConnection">The own connection.</param>
        public AdoUnitOfWork(IDbConnection connection, bool ownConnection)
            : this(connection, ownConnection, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdoUnitOfWork"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="ownConnection">The own connection.</param>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DataException"></exception>
        public AdoUnitOfWork(IDbConnection connection, bool ownConnection, IsolationLevel isolationLevel)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            if (connection.State != ConnectionState.Open)
            {
                throw new DataException("Connection '" + connection.ConnectionString + "' is not open.");
            }

            this.connection = connection;
            this.ownConnection = ownConnection;

            this.transaction = isolationLevel != 0
                                   ? connection.BeginTransaction(isolationLevel)
                                   : connection.BeginTransaction();

            this.repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
                this.transaction = null;
            }

            if (this.ownConnection && this.connection != null)
            {
                this.connection.Dispose();
                this.connection = null;
            }
        }

        /// <summary>
        ///     Commit changes.
        /// </summary>
        /// <exception cref="Exception">Transaction have already been commited or disposed.</exception>
        public void SaveChanges()
        {
            if (this.transaction == null)
            {
                throw new Exception("The connection has already been closed.");
            }

            this.transaction.Commit();
        }

        /// <summary>
        /// Gets a repository for a given TData.
        /// </summary>
        /// <typeparam name="TData">The TData for which we want a repository</typeparam>
        /// <returns>The repository for TData</returns>
        public IRepository<TData> GetRepository<TData>() where TData :class, new()
        {
            IRepository<TData> repository = null;
            if (this.repositories.ContainsKey(typeof(TData)))
            {
                repository = this.repositories[typeof(TData)] as IRepository<TData>;
            }
            else
            {
                if (typeof(TData) == typeof(Student))
                {
                    repository = (IRepository<TData>)new StudentRepository(this.transaction, this);
                }
                else if (typeof(TData) == typeof(Clase))
                {
                    repository = (IRepository<TData>)new ClaseRepository(this.transaction, this);
                }

                this.repositories[typeof(TData)] = repository;
            }

            return repository;
        }
    }
}