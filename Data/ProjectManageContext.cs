using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PMS_Net.Models;
using System.Configuration;

namespace PMS_Net.Data
{
    public class ProjectManageContext : DbContext
    {

        public DbSet<Project> projects { get; set; }

        private readonly IConfiguration _configuration;
        public ProjectManageContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("Database");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
