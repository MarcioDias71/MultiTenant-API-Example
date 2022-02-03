using System;
using System.Linq;
using System.Threading.Tasks;
using Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {


        private readonly TenantContext _context;

        public UsuarioRepository(TenantContext context)
        {
            _context = context;
        }
        public async Task<object> TestarConexaoAsync()
        {
            return await _context.Clientes.FirstOrDefaultAsync(p => p.CodCliente < 100);
        }
    }
}
