using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class SqlServerContext : CommanderContext
    {
        public SqlServerContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("SqlServer"),
                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
        }
    }
}
