using AutoMapper;
using Commander.DTOs;
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
        private readonly IMapper _mapper;

        public CommandsController(ICmdrRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommandReadDto>>> GetAllCommands()
        {
            var commandItems = await _repository.GetAllCommandsAsync();
            if (commandItems == null)
            {
                return NotFound();
            }

            var commandDtos = _mapper.Map<IEnumerable<CommandReadDto>>(commandItems);

            return Ok(commandDtos);
        }

        // GET api/commands/5
        [HttpGet("{id}", Name = "GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            var commandItem = await _repository.GetCommandByIdAsync(id);
            if (commandItem == null)
            {
                return NotFound();
            }

            var commandDto = _mapper.Map<CommandReadDto>(commandItem);

            return Ok(commandDto);
        }

        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            await _repository.SaveChangesAsync();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandModel.Id }, commandReadDto);
        }
    }
}
