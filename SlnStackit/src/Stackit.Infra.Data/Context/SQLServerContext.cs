using Microsoft.EntityFrameworkCore;
using Stackit.Domain.Entities;
using Stackit.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackit.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship mapping
            modelBuilder.Entity<Publication>()
                .HasOne(publication => publication.User)
                .WithMany(user => user.Publications)
                .HasForeignKey(publication => publication.UserId);

            // Seed
            modelBuilder.Entity<User>()
                .HasData(
                    new { Id = 1, Username = "Admin", Email = "admin@gmail.com", Password = "admin", Profile = ProfileEnum.Admin}
                );
        }

        #region DbSets
        public DbSet<User> User { get; set; }
        public DbSet<Publication> Publication { get; set; }
        #endregion
    }
}
