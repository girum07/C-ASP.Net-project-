﻿using Domain.Interface.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections;


namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IdentityDbContext context;
        private Hashtable repositories;

        public UnitOfWork(IdentityDbContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesReturnBool()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenerciRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories == null) repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);

                repositories.Add(type, repositoryInstance);
            }

            return (IGenerciRepository<TEntity>)repositories[type];
        }
    }
}

