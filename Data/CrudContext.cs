using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> opts) : base(opts){
            //var configuration = new ConfigurationBuildaer()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsetting.json")
            //    .Build();

            //var connectionString = configuration.GetConnectionString("MySqlConnectionString");

            //optsbd.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            
        }
        public DbSet<User> Users { get; set; }
    }
}
