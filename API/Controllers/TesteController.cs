using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Configurations;
using Manager.Interfaces;
using Manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {


        private readonly IUsuarioService _service;



        public TesteController(IUsuarioService service)
        {
            _service = service;
        }



    


        [HttpGet]


        public async Task<IActionResult> TestarConexaoAsync(){



            var result = await _service.TestarConexaoAsync();

            return Ok(result);
            
        }
        
        
    }
}
