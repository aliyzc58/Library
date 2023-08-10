using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        public DbSet<Book> Books { get; set; }
        public DbSet<LoanedBook> LoanedBooks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuration dosyalarını şuan çalıştığımız assembly içerisinden getir diyoruz 
            //şuan çalıştığımız proje = data katmanı - klasörü oluyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }


        public override int SaveChanges()
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entity)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.Status = true;
                            entity.CreateDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
