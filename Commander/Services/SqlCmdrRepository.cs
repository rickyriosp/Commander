using Commander.Data;
using Commander.Models;
using Commander.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Commander.Services
{
    public class SqlCmdrRepository : ICmdrRepository
    {
        private readonly CommanderContext _context;

        public SqlCmdrRepository(CommanderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            var commandItems = await _context.Commands.ToListAsync();
            return commandItems;
        }

        public async Task<Command> GetCommandByIdAsync(int id)
        {
            var commandItem = await _context.Commands.FirstOrDefaultAsync(c => c.Id == id);
            return commandItem;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Add(command);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
