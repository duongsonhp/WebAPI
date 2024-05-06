using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using ConfigurationFile = Utilities.Enums.File.ConfigurationFile;

namespace DataLayer
{
    public class CollegeContext : DbContext
    {
        //public CollegeContext(DbContextOptions<CollegeContext> options)
        //: base(options)
        //{
        //}

        public DbSet<Student> Students { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<FacultyStudent> FacultyStudents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var buildedConfiguration = builder.Build();

            var connectionString = buildedConfiguration.GetSection("ConnectionStrings").GetSection("college").Value;

            // var connectionString = buildedConfiguration.GetConnectionString("test")/*.GetSection("test").Value*/;

            // FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] Connection" });

            // optionsBuilder.UseSqlServer(FileUtility.ReadSection(ConfigurationFile.ConnectionConfiguration, "connectionString"));
            optionsBuilder.UseSqlServer(connectionString);
            // optionsBuilder.UseMySQL(connectionString);
        }
    }
}
