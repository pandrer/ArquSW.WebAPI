using Microsoft.EntityFrameworkCore;

namespace ArquSW.WebAPI.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<RadicarDocumento> RadicarDocumento { get; set; }
        public DbSet<Documento> Documento { get; set; }

    }

    public class RadicarDocumento
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public Documento Documento { get; set; }
    }

    public class Documento
    {
        public int Id { get; set; }
        public string NombreDocumento { get; set; }
        public string Ruta { get; set; }
        public ExtencionDocumento ExtencionDocumento { get; set; }
    }

    public enum ExtencionDocumento
    {
        PDF,
        JPG,
        PNG
    }
}
