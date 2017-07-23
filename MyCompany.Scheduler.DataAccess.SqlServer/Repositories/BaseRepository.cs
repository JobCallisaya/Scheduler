// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the BaseRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.SqlServer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using MyCompany.Scheduler.Commons;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TData">
    /// The data type parameter.
    /// </typeparam>
    public abstract class BaseRepository<TData>  : IRepository<TData> where TData : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TData}"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public BaseRepository(IDbTransaction transaction, IUnitOfWork unitOfWork)
        {
            Validator.ValidateNullArgument(transaction, "transaction");
            Validator.ValidateNullArgument(unitOfWork, "unitOfWork");
            this.Transaction = transaction;
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        protected IDbTransaction Transaction { get; private set; }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public abstract IEnumerable<TData> Get();

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="TData"/>.</returns>
        public abstract TData Get(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public abstract IEnumerable<TData> Get(List<CustomExpression> filter);

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        public abstract void Add(TData data);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="data">The data.</param>
        public abstract void Update(int id, TData data);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">The id.</param>
        public abstract void Remove(int id);

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="data">The data.</param>
        public abstract void Remove(TData data);

        /// <summary>
        /// The remove.
        /// </summary>
        public abstract void Remove();

        /// <summary>
        /// Adapts a command into data.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="adapt">The adapt.</param>
        /// <typeparam name="TData">The data type parameter</typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        protected static IEnumerable<TData> Adapt<TData>(IDbCommand command, Func<IDataReader, TData> adapt) where TData : class, new()
        {
            using (var reader = command.ExecuteReader())
            {
                var data = new List<TData>();
                while (reader.Read())
                {
                    data.Add(adapt(reader));
                }

                return data;
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <typeparam name="TRestult">The result type parameter.</typeparam>
        /// <returns>The <see cref="TRestult"/>.</returns>
        protected TRestult ExecuteCommand<TRestult>(Func<IDbCommand, TRestult> action)
        {
            var command = this.Transaction.Connection.CreateCommand();
            try
            {
                command.Transaction = this.Transaction;
                return action(command);
            }
            finally
            {
                command.Dispose();
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="action">The action.</param>
        protected void ExecuteCommand(Action<IDbCommand> action)
        {
            var command = this.Transaction.Connection.CreateCommand();
            try
            {
                command.Transaction = this.Transaction;
                action(command);
            }
            finally
            {
                command.Dispose();
            }
        }

        /// <summary>
        /// The get where clause.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="string"/>.</returns>
        protected string GetWhereClause(List<CustomExpression> filter)
        {
            string where = @"WHERE";
            IEnumerable<string> fields =
                filter.Select(expression => string.Format(" {0} = '{1}'", expression.Field, expression.Value));
            string fieldsString = string.Join(" AND", fields);
            return string.Format("{0} {1}", where, fieldsString);
        }
    }
}
