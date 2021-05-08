using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public interface IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Board> Boards { get; set; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
