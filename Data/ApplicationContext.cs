using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PMS_Net.Models;
using System.Configuration;

namespace PMS_Net.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Project> projects { get; set; }

        private readonly IConfiguration _configuration;
        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString("Database");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string data = System.IO.File.ReadAllText("projects.json");
            JToken jObject = JObject.Parse(data);
            jObject = jObject["projects"];
            List<Project> _projectList = JsonConvert.DeserializeObject<List<Project>>(jObject.ToString());

            modelBuilder.Entity<Project>().HasData(_projectList.ToArray());

            base.OnModelCreating(modelBuilder);
        }
    }
}
