using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Domain;
using Manager.Interfaces;
using CrossCuting;
using Microsoft.Extensions.Configuration;


using Newtonsoft.Json.Linq;


namespace Manager.Services
{
    public class EmpresaService : IEmpresaService
    {


        private readonly IEmpresaRepository _repository;

        private readonly IConfiguration _configuration;







        public EmpresaService(IEmpresaRepository repository, IConfiguration configuration)
        {

            _repository = repository;
            _configuration = configuration;

        }

        public async Task<object> CadastrarEmpresaAsync(Empresa empresa)
        {


            var ConnectionString = $"User ID={empresa.EmpresaConexao.User_Id};Server={empresa.EmpresaConexao.Servidor};Database={empresa.EmpresaConexao.NomeDoBanco};Password={empresa.EmpresaConexao.Senha};";

            var resposta = await _repository.CadastrarEmpresaAsync(empresa);

            var ID = (int)Utils.PegaValorPropriedade(resposta, "CodEmpresa");


            var hash = GerarHashMd5(ID.ToString());

            RdWrJsonFile(hash, ConnectionString);


            return resposta;


        }

        public async Task<string> PegarConnectStringAsync(int ID_USER, int ID_EMPRESA)
        {
            return await _repository.PegarConnectStringAsync(ID_USER, ID_EMPRESA);
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



           public static void RdWrJsonFile(string hash, string connectionString)
        {



         

            string filepath = Directory.GetCurrentDirectory() +  @"\appsettings.json";




            string readResult = string.Empty;
            string writeResult = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);
                var Elements = jobj["ConnectionStrings"] as JObject;
                readResult = jobj.ToString();
                
                Elements.AddFirst(new JProperty(hash, connectionString));
                writeResult = jobj.ToString();

                

            }
            File.WriteAllText(filepath, writeResult);
            
        }
    }

}
