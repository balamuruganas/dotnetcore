﻿using Microsoft.EntityFrameworkCore;
using Seaknots.TCMS.Core.Abstractions.EF;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Seaknots.TCMS.Core.Concrete.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await Context.SaveChangesAsync(cancellationToken);

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
            => await Context.Database.ExecuteSqlCommandAsync(sql, parameters, cancellationToken);
    }
}