using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Empresa
    {
        public string Nome { get; set; }

        [Key]
        public int ID { get; set; }
        
        public List<Usuario> Usuarios { get; set; }


        public EmpresaConexao EmpresaConexao { get; set; }







    }
}