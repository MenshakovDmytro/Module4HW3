using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW3.Data;

namespace Module4HW3.Helper
{
    public class Starter
    {
        public void Run()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.
                UseSqlServer(connectionString)
                .Options;
            using (var db = new ApplicationDbContext(options))
            {
            }

            System.Console.ReadLine();
        }
    }
}