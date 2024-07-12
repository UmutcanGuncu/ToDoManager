using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Application.Abstracts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoManager.WebAPI.Controllers
{
    [ApiController]
    [Route("logView")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class LogViewController : Controller
    {
        private readonly ILogViewRepository _logViewRepository;

        public LogViewController(ILogViewRepository logViewRepository)
        {
            _logViewRepository = logViewRepository;
        }

        [HttpGet]
        public IActionResult ListLogView()
        {
            var values = _logViewRepository.GetLogView();
            return Ok(values);
        }
    }
}

