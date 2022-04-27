using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public CommanderContext(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        public DbSet<Command> Commands { get; set; }
    }
}
