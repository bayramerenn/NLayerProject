using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Service;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IService<Person> _service;

        public PersonController(IService<Person> service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _service.GetAllAsync();

            return Ok(persons);
        }
    }
}