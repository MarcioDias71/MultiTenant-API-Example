using Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public virtual DbSet<Empresa> Empresas { get; set; }

        public virtual DbSet<EmpresaConexao> EmpresasConexoes { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        
        


    }

}