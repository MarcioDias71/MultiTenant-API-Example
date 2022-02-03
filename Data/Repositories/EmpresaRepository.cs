using System;
using System.Linq;
using System.Threading.Tasks;
using Manager;
using Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EmpresaRepository: IEmpresaRepository
    {



        private readonly AppDbContext _context;



        public EmpresaRepository(AppDbContext context)
        {


            _context = context;
            

        }

        public async Task<object> CadastrarEmpresaAsync(Core.Domain.Empresa empresa)
        {



            try{


                empresa.ID = (await _context.Empresas.MaxAsync(p => (int?)p.ID)??0)+1;
                empresa.EmpresaConexao.ID_EMPRESA = empresa.ID;

                empresa.EmpresaConexao.ID = (await _context.EmpresasConexoes.MaxAsync(p => (int?)p.ID)??0)+1;

                empresa.Usuarios.FirstOrDefault().ID = (await _context.Usuarios.MaxAsync(p => (int?)p.ID)??0)+1;



                empresa.Usuarios.FirstOrDefault().ID_EMPRESA = empresa.ID;
                await _context.AddAsync(empresa);

                await _context.SaveChangesAsync();

                return new
                {
                    message = "Sucesso ao adicionar",
                    CodEmpresa = empresa.ID
                };
            }
            
            catch(Exception e){


                Console.Write(e);
                 return new
                {
                    message = "Erro ao adicionar"
                };


            }


        }

        public async Task<string> PegarConnectStringAsync( int ID_USER, int ID_EMPRESA){



            var EmpresaConexao = await _context.EmpresasConexoes.FirstOrDefaultAsync( p => p.ID_EMPRESA == ID_EMPRESA);

            var ConnectionString = $"User ID={EmpresaConexao.User_Id};Server={EmpresaConexao.Servidor};Database={EmpresaConexao.NomeDoBanco};Password={EmpresaConexao.Senha};";

            return ConnectionString;


        }

    }
}
