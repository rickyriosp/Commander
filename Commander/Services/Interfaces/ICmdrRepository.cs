using Commander.Models;

namespace Commander.Services.Interfaces
{
    public interface ICmdrRepository
    {
        Task<IEnumerable<Command>> GetAllCommandsAsync();
        Task<Command> GetCommandByIdAsync(int id);
        void CreateCommand(Command command);
        Task<bool> SaveChangesAsync();
        Task UpdateCommandAsync(Command command);
        Task DeleteCommandAsync(Command command);
    }
}
