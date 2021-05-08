using System;
using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class DataContext : DbContext , IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Board> Boards { get; set; }

    }
}
