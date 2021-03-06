using AutoMapper;
using Commander.DTOs;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandUpsertDto, Command>();
            CreateMap<Command, CommandUpsertDto>();
        }
    }
}
