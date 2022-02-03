using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using System;

namespace Data
{
    public partial class TenantContext : DbContext
    {


        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IConfiguration _configuration;

        public TenantContext(DbContextOptions<TenantContext> options, IHttpContextAccessor httpContextAcessor, IConfiguration configuration ) : base(options) {

            _httpContextAccessor = httpContextAcessor;
            _configuration = configuration;
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder.IsConfigured)
                return;
            var connectionString = string.Empty;
            var companyId = _httpContextAccessor.HttpContext.Items.FirstOrDefault(p => p.Key.ToString() == "hash").Value;
            connectionString = _configuration.GetConnectionString(companyId.ToString());
            optionsBuilder.UseSqlServer(connectionString);

        }
    }

}