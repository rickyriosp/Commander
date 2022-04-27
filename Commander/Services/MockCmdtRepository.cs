using Commander.Models;
using Commander.Services.Interfaces;

namespace Commander.Services
{
    public class MockCmdtRepository : ICmdrRepository
    {
        public async Task<IEnumerable<Command>> GetAllCommandsAsync()
        {
            var commands = new List<Command>()
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "Knife & Chopping Board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place teabag in cup", Platform = "Kettle & Cup" }
            };

            return commands;
        }

        public async Task<Command> GetCommandByIdAsync(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public void CreateCommand(Command command)
        {
            return;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return true;
        }

        public async Task UpdateCommandAsync(Command command)
        {
            return;
        }

        public async Task DeleteCommandAsync(Command command)
        {
            return;
        }
    }
}
