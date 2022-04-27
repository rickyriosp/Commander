using Commander.Models;
using Commander.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICmdrRepository _repository;

        public CommandsController(ICmdrRepository repository)
        {
            _repository = repository;
        }

        // GET api/commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetAllCommands()
        {
            var commandItems = await _repository.GetAllCommandsAsync();

            return Ok(commandItems);
        }

        // GET api/commands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Command>> GetCommandById(int id)
        {
            var commandItem = await _repository.GetCommandByIdAsync(id);

            return Ok(commandItem);
        }
    }
}
