using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class PostgreSqlContext : CommanderContext
    {
        public PostgreSqlContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("PostgreSql"),
                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
