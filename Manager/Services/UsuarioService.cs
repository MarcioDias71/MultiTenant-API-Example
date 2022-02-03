using System;
using System.Threading.Tasks;
using Manager.Interfaces;

namespace Manager.Services
{
    public class UsuarioService : IUsuarioService
    {


        private readonly IUsuarioRepository _repository;

        public UsuarioService()
        {
        }

        public UsuarioService(IUsuarioRepository repository)
        {

            _repository = repository;

        }
        public async Task<object> TestarConexaoAsync()
        {
            return await _repository.TestarConexaoAsync();
        }
    }
}
