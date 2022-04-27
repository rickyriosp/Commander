using Commander.Models;

namespace Commander.Services.Interfaces
{
    public interface ICRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}
