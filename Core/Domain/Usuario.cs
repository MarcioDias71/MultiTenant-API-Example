using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Usuario
    {

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public int ID_EMPRESA { get; set;  }


        [ForeignKey("ID_EMPRESA")]
        public Empresa Empresa { get; set; }






    }
}