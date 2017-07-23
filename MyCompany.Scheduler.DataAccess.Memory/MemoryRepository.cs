// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Represents a repository. Holds a collection of data and provides actions over this data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.Memory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// Represents a repository. Holds a collection of data and provides actions over this data.
    /// </summary>
    /// <typeparam name="TData">The data type</typeparam>
    public class MemoryRepository<TData> : IRepository<TData> where TData : class, new()
    {
        /// <summary>
        /// The data set.
        /// </summary>
        private Dictionary<int, TData> dataSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryRepository{TData}"/> class. 
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// When context is null.
        /// </exception>
        public MemoryRepository()
        {
            this.dataSet = new Dictionary<int, TData>();
        }

        /// <summary>
        /// Gets all data from repository
        /// </summary>
        /// <returns>All data from repository</returns>
        public virtual IEnumerable<TData> Get()
        {
            return this.dataSet.Values.AsQueryable();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public virtual IEnumerable<TData> Get(List<CustomExpression> filter)
        {
            return this.dataSet.Values.ToList().Where(data => this.Matches(data, filter));
        }

        /// <summary>
        /// Gets data with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The data with identifier id</returns>
        public virtual TData Get(int id)
        {
            TData data = default(TData);

            if (this.dataSet.ContainsKey(id))
            {
                data = this.dataSet[id];
            }

            return data;
        }

        /// <summary>
        /// Adds data to repository
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>The added data</returns>
        public virtual void Add(TData data)
        {
            var dataId = this.GetDataId(data);
            this.dataSet.Add(dataId, data);
        }

        /// <summary>
        /// Updates data in the repository
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data to be updated
        /// </param>
        /// <returns>
        /// The updated data
        /// </returns>
        public virtual void Update(int id, TData data)
        {
            if (this.dataSet.ContainsKey(id))
            {
                this.dataSet[id] = data;
            }
        }

        /// <summary>
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data to be removed</param>
        /// <returns>The removed data</returns>
        public virtual void Remove(TData data)
        {
            var dataId = this.GetDataId(data);

            if (this.dataSet.ContainsKey(dataId))
            {
                this.dataSet.Remove(dataId);
            }
        }

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        public virtual void Remove(int id)
        {
            TData data = default(TData);
            if (this.dataSet.ContainsKey(id))
            {
                data = this.dataSet[id];
                this.dataSet.Remove(id);
            }
        }

        /// <summary>
        /// Removes all data in repository
        /// </summary>
        public void Remove()
        {
            this.dataSet.Clear();
        }

        /// <summary>
        /// Gets the data identifier from data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The data identifier</returns>
        private int GetDataId(TData data)
        {
            return data.GetHashCode();
        }

        /// <summary>
        /// The matches.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Matches(TData data, CustomExpression expression)
        {
            bool result = false;
            Type type = typeof(TData);
            foreach (var property in type.GetProperties())
            {
                var propertyValue = property.GetValue(data).ToString();
                if (property.Name == expression.Field &&
                    propertyValue == expression.Value)
                {
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// The matches.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool Matches(TData data, List<CustomExpression> filter)
        {
            return filter.TrueForAll(expression => this.Matches(data, expression));
        }
    }
}
