using Microsoft.AspNetCore.Mvc;
using ToDoManager.Application.Abstracts;
using ToDoManager.Application.Dtos.CheckpointDtos;
using ToDoManager.Domain.Entities;

namespace ToDoManager.WebAPI.Controllers;

[ApiController]
[Route("checkpoint")]
public class CheckpointController : ControllerBase
{
   private readonly ICheckpointRepository _checkpointRepository;

   public CheckpointController(ICheckpointRepository checkpointRepository)
   {
      _checkpointRepository = checkpointRepository;
   }

   [HttpGet]
   public IActionResult ListCheckpoint()
   {
      var values = _checkpointRepository.GetAll();
      return Ok(values);
   }

   [HttpGet("{id}")]
   public IActionResult CheckpointGetById(int id)
   {
      var value = _checkpointRepository.GetById(id);
      return Ok(value);
   }

   [HttpPost]
   public IActionResult AddCheckpoint(AddCheckpointDto dto)
   {
      var checkpoint = new Checkpoint()
      {
         Name = dto.Name
      };
      _checkpointRepository.Add(checkpoint);
      return Ok();
   }

   [HttpPut]
   public IActionResult UpdateCheckpoint(UpdateCheckpointDto dto)
   {
      var checkpoint = new Checkpoint()
      {
         Id = dto.Id,
         Name = dto.Name
      };
      _checkpointRepository.Update(checkpoint);
      return Ok();
   }
}