// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Represents a repository. Holds a collection of data and provides actions over this data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.InMemory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    using global::MyCompany.Scheduler.DataAccess.MyCompany.Scheduler.DataAccess;

    /// <summary>
    /// Represents a repository. Holds a collection of data and provides actions over this data.
    /// </summary>
    /// <typeparam name="TData">The data type</typeparam>
    public class MemoryRepository<TData> : IRepository<TData> where TData : class
    {
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
        public virtual IQueryable<TData> Get()
        {
            return this.dataSet.Values.AsQueryable();
        }

        /// <summary>
        /// Gets data with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The data with identifier id</returns>
        public virtual TData Get(int id)
        {
            TData data = null;

            if (this.dataSet.ContainsKey(id))
            {
                data = this.dataSet[id];
            }

            return data;
        }

        /// <summary>
        /// Gets data by an specified filter, orders the data given a function and retreives the specified properties
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="orderBy">The orderBy function</param>
        /// <param name="properties">The properties</param>
        /// <returns>A filtered and ordered IEnumerable of data</returns>
        public virtual IEnumerable<TData> Get(
            Expression<Func<TData, bool>> filter = null,
            Func<IQueryable<TData>, IOrderedQueryable<TData>> orderBy = null,
            params string[] properties)
        {
            IEnumerable<TData> result = new List<TData>();
            IQueryable<TData> query = this.dataSet.Values.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                result = orderBy(query).ToList();
            }
            else
            {
                result = query.ToList();
            }

            return result;
        }

        /// <summary>
        /// Adds data to repository
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>The added data</returns>
        public virtual TData Add(TData data)
        {
            var dataId = GetDataId(data);
            this.dataSet.Add(dataId, data);
            return data;
        }

        /// <summary>
        /// Updates data in the repository
        /// </summary>
        /// <param name="data">The data to be updated</param>
        /// <returns>The updated data</returns>
        public virtual TData Update(TData data)
        {
            var dataId = GetDataId(data);
            if (this.dataSet.ContainsKey(dataId))
            {
                this.dataSet[dataId] = data;
            }
            return data;
        }

        /// <summary>
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data to be removed</param>
        /// <returns>The removed data</returns>
        public virtual TData Remove(TData data)
        {
            var dataId = GetDataId(data);

            if (this.dataSet.ContainsKey(dataId))
            {
                this.dataSet.Remove(dataId);
            }

            return data;
        }

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        public virtual TData Remove(int id)
        {
            TData data = null;
            if (this.dataSet.ContainsKey(id))
            {
                data = this.dataSet[id];
                this.dataSet.Remove(id);
            }

            return data;
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
            int dataId = -1;
            PropertyInfo propertyId = data.GetType().GetProperties().FirstOrDefault(info => info.Name == "Id");

            if (propertyId != null)
            {
                dataId = (int)propertyId.GetValue(data);
            }

            return dataId;
        }
    }
}
