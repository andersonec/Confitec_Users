using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using users.Infra.Entities;

namespace users.Infra.Data.DbConfig
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        #region DBSETS
        public DbSet<User> Users { get; set; }
        public DbSet<Schooling> Schoolings { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
