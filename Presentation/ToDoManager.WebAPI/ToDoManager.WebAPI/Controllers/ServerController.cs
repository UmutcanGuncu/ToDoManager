using Microsoft.AspNetCore.Mvc;
using ToDoManager.Application.Abstracts;
using ToDoManager.Application.Dtos.ServerDtos;
using ToDoManager.Domain.Entities;

namespace ToDoManager.WebAPI.Controllers;

[ApiController]
[Route("server")]
public class ServerController : ControllerBase
{
   private readonly IServerRepository _serverRepository;

   public ServerController(IServerRepository serverRepository)
   {
      _serverRepository = serverRepository;
   }

   [HttpGet]
   public IActionResult ServerList()
   {
      var values = _serverRepository.GetAll();
      return Ok(values);
   }

   [HttpGet("{id}")]
   public IActionResult ServerListById(int id)
   {
      var value = _serverRepository.GetById(id);
      return Ok(value);
   }
   [HttpPost]
   public IActionResult AddServer(AddServerDto serverDto)
   {
      Server server = new Server()
      {
         Name = serverDto.Name,
         Ip = serverDto.Ip
      };
      _serverRepository.Add(server);
      return Ok();
   }

   [HttpPut]
   public IActionResult UpdateServer(UpdateServerDto updateServerDto)
   {
      Server server = new Server()
      {
         Id = updateServerDto.Id,
         Name = updateServerDto.Name,
         Ip = updateServerDto.Ip
      };
      _serverRepository.Update(server);
      return Ok();
   }
}