using Microsoft.EntityFrameworkCore;
using RegistroVentas.Entidades;

namespace RegistroVentas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=Data/Ventas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Articulos>().HasData(new Articulos(){ArticuloId = 1, Descripcion = "Jabon", Precio = 150});
            modelBuilder.Entity<Articulos>().HasData(new Articulos(){ArticuloId = 2, Descripcion = "Habichuelas", Precio = 55});
            modelBuilder.Entity<Articulos>().HasData(new Articulos(){ArticuloId = 3, Descripcion = "Salami", Precio = 60});
            
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {​​​​

        //     base.OnModelCreating(modelBuilder); 

        //     modelBuilder.Entity<Articulos>().HasData(new Articulos() {​​​​ ArticuloId = 1, Descripcion = "Jabon", Precio = 150 }​​​​);            

        //     modelBuilder.Entity<Articulos>().HasData(new Articulos() {​​​​ ArticuloId = 2, Descripcion = "Habichuelas", Precio = 55 }​​​​);            

        //     modelBuilder.Entity<Articulos>().HasData(new Articulos() {​​​​ ArticuloId = 3, Descripcion = "Salami", Precio = 60 }​​​​);

        // }​​​​
    }

}