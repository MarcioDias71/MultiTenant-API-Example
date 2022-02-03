using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Configurations;
using Core.Domain;
using Manager.Interfaces;
using Manager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {


        private readonly IEmpresaService _service;


        public LoginController(IEmpresaService service)
        {
            _service = service;
        }



        [HttpGet]

        public async Task<IActionResult> ConnectarAsync(int ID_USER, int ID_EMPRESA){

            var ConnectionString = await _service.PegarConnectStringAsync(ID_USER, ID_EMPRESA);


            Response.Cookies.Append("hash",GerarHashMd5(ID_EMPRESA.ToString()));

            return Ok(ConnectionString);


        } 


        [HttpPost]

        public async Task<IActionResult> CadastrarEmpresaAsync(Empresa empresa){


            var result = await _service.CadastrarEmpresaAsync(empresa);

            return Ok(result);


        }


             public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }



 
        
        
    }
}
