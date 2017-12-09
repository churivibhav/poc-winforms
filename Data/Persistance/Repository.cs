﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Data;

namespace Data.Persistance
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext dbctx;
        private IDbSet<T> entities;
        private string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            dbctx = context;
        }

        public void Add(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                Entities.Add(item);
                dbctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage +=
                            $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, e);
            }
        }

        public void Update(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
                dbctx.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine +
                                        $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                    }
                }

                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Delete(T item)
        {
            try
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }

                this.Entities.Remove(item);
                this.dbctx.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += Environment.NewLine +
                                        $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Attach(T item) => Entities.Attach(item);

        public virtual IQueryable<T> AsQueryable() => Entities as IQueryable<T>;

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public T Get(int id) => Entities.Find(id);

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = dbctx.Set<T>();
                }
                return entities;
            }
        }
    }
}