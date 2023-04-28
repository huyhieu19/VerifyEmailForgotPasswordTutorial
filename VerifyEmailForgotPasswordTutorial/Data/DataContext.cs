using Microsoft.Extensions.Configuration;
using VerifyEmailForgotPasswordTutorial.Models;

namespace VerifyEmailForgotPasswordTutorial.Data
{
    public class DataContext : DbContext
    {
        public IConfiguration Configuration { get; }


        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users => Set<User>();
    }
}
