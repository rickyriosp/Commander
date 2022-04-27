using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using Commander.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

        // POST api/commands
        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(CommandUpsertDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);
            await _repository.SaveChangesAsync();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandModel.Id }, commandReadDto);
        }

        // PUT api/commands/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, CommandUpsertDto commandUpdateDto)
        {
            var commandModelFromRepo = await _repository.GetCommandByIdAsync(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            await _repository.UpdateCommandAsync(commandModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }

        // PATCH api/commands/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialCommandUpdate(int id, JsonPatchDocument<CommandUpsertDto> patchDoc)
        {
            var commandModelFromRepo = await _repository.GetCommandByIdAsync(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            if (patchDoc == null)
            {
                return BadRequest();
            }

            var commandToPatch = _mapper.Map<CommandUpsertDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            await _repository.UpdateCommandAsync(commandModelFromRepo);
            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
