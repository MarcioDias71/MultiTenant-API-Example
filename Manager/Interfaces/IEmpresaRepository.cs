using System;
using System.Threading.Tasks;
using Core.Domain;

namespace Manager.Interfaces
{
    public interface IEmpresaRepository
    {

        Task<string> PegarConnectStringAsync(int ID_USER, int ID_EMPRESA);

        Task<Object> CadastrarEmpresaAsync(Empresa empresa);


    }
}
