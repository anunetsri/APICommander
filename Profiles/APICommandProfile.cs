using APICommander.Models;
using APICommander.DTOs;
using AutoMapper;

namespace APICommander.Profiles
{
    public class APICommandProfile : Profile
    {
        public APICommandProfile()
        {
            //Source -> Target
            CreateMap<APICommand,CommandReadDTO>();
            CreateMap<CommandCreateDTO,APICommand>();
            CreateMap<CommandUpdateDTO,APICommand>();
            CreateMap<APICommand,CommandUpdateDTO>();
        }
    }
}