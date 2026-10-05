using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SameApi.Db.DbContexts;

namespace SameApi.Db
{
    public static class DbConfigurationExtension
    {
        public static void AddSameApibContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SameApiDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                  .UseRelationalNulls()
                  .EnableRetryOnFailure(
                      maxRetryCount: 5,                // combien de fois on réessaye
                      maxRetryDelay: TimeSpan.FromSeconds(30), // délai max entre 2 tentatives
                      errorNumbersToAdd: null          // erreurs SQL spécifiques (null = toutes par défaut)
                  );
        sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
    }));
        }
    }
}