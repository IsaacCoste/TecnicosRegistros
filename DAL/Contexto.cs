using Microsoft.EntityFrameworkCore;
using TecnicosRegistros.Models;

namespace TecnicosRegistros.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Tecnicos> Tecnicos { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}