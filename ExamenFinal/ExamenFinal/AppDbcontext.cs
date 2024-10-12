using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Usuarioo> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("DESKTOP-SB259SK\\SQLEXPRESS");
    }
    public class Producto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
    }

    public class Usuarioo
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
    }
}
