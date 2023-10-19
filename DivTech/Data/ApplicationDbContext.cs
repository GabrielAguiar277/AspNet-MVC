using DivTech.Models;
using Microsoft.EntityFrameworkCore;

namespace DivTech.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FornecedorModel> Fornecedor { get; set; }

    }
}
