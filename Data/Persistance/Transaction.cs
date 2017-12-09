﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Persistance;

namespace Data.Repositories
{
    public class Transaction : IDisposable
    {
        private readonly DbContext dbctx;
        private bool disposed;
        private Dictionary<string, object> repositories;

        public Transaction()
        {
            dbctx = CompanyDbContext.CreateContext();
        }

        public Transaction(DbContext context)
        {
            dbctx = context;
        }

        // Save Transaction
        public void Commit()
        {
            dbctx.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
                dbctx.Dispose();
            disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>); // Repository concrete type here
                var repoInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), dbctx);
                repositories.Add(type, repoInstance);
            }
            return repositories[type] as IRepository<T>;
        }
    }
}
