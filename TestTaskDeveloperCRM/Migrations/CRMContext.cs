using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net;
using System.Numerics;
using System.Reflection;
using TestTaskDeveloperCRM.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestTaskDeveloperCRM.Migrations
{
    public class CRMContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<LegalEntity> Companies { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=crm.db")
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
               .EnableSensitiveDataLogging()
               .EnableDetailedErrors();
            // Установка текущей культуры
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU"); 

        }
    }
}
