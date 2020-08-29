using APICommander.Data;
using APICommander.Models;
using APICommander.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace APICommander.Controllers
{
    //api/APICommandsContraoller-Output Route
    [Route("api/commands")]
    [ApiController]
    public class APICommandsController : ControllerBase
    {
        private readonly IAPICommanderRepo _repository;
        private readonly IMapper _mapper;

        // public APICommandsController(IAPICommanderRepo repository)
        // {//Assigned the Dependency injected value to the private field used at the class level
        //     _repository=repository;
        // }
        public APICommandsController(IAPICommanderRepo repository,IMapper Mapper)
        {
            _repository=repository;
            _mapper=Mapper;
        }
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //API End Points start
        //GET api/commandss
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands()
            {
                var commandItems = _repository.GetAllCommands();

                return Ok(_mapper.Map<IEnumerable<CommandReadDTO>> (commandItems));
            }
        //GET api/commands/{id}$
        [HttpGet("{id}",Name="GetCommandById")]
        //[Route]
        public ActionResult <CommandReadDTO> GetCommandById(int id)
        {
            var commandItem =_repository.GetCommandById(id);
            if(commandItem!=null)
            {
                //return Ok(commandItem);
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
        }
        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreateDTO commandCreateDTO)
        {
            var commandModel=_mapper.Map<APICommand>(commandCreateDTO);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var CommandReadDTO=_mapper.Map<CommandReadDTO>(commandModel);
// return Ok(commandModel) this returns plain model without applying our contract i.e.hiding platform
            //return Ok(CommandReadDTO); this return ok but code should be 201 with id
            return CreatedAtRoute(nameof(GetCommandById),new {id = CommandReadDTO.Id},CommandReadDTO);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDTO commandUpdateDTO)
        {
            var commandmodelfromrepo=_repository.GetCommandById(id);
            if(commandmodelfromrepo== null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDTO,commandmodelfromrepo);

            _repository.UpdateCommand(commandmodelfromrepo);
            _repository.SaveChanges();

            return NoContent();

        }
        //Patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id,JsonPatchDocument<CommandUpdateDTO> patchdoc)
        {
            var commandmodelfromrepo=_repository.GetCommandById(id);
            if(commandmodelfromrepo== null)
            {
                return NotFound();
            }
            //using Profile  CreateMap<APICommand,CommandUpdateDTO>();
            var commandTtoPatch=_mapper.Map<CommandUpdateDTO>(commandmodelfromrepo);
            patchdoc.ApplyTo(commandTtoPatch,ModelState);
            if(!TryValidateModel(commandTtoPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandTtoPatch,commandmodelfromrepo);

            _repository.UpdateCommand(commandmodelfromrepo);
            _repository.SaveChanges();

            return NoContent();

        }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        //Comment For Git
        public ActionResult DeleteCommand(int id)
        {
            var commandmodelfromrepo=_repository.GetCommandById(id);
            if(commandmodelfromrepo== null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandmodelfromrepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}