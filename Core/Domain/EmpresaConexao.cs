using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class EmpresaConexao
    {


        [Key]
        public int ID { get; set; }
        
        
        [ForeignKey("EmpresaNavigation")]
        public int ID_EMPRESA { get; set; }
        
        public string Servidor { get; set; }
        
        public int Porta { get; set; }


        public string Senha { get; set; }

        public string NomeDoBanco { get; set; }

        public string User_Id { get; set; }



        public Empresa EmpresaNavigation { get; set; }
        
        
        
        
    }
}