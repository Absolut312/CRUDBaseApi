using System;
using BaseApi.DAL.Core;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Test.Core
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbBaseModel>().HasData(new DbBaseModel
            {
                Id = 1,
                CreationDate = DateTime.Now,
                ModificationTime = DateTime.Now,
                IsDeleted = false
            });
        }

        public DbSet<DbBaseModel> BaseModels { get; set; }
    }
}