using Microsoft.EntityFrameworkCore;
using Heroes.Models;

namespace Heroes.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options) : base(options) { }

        public DbSet<Hos> Hosok { get; set; }
        public DbSet<Kaszt> Kasztok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kaszt>().HasData(
                new Kaszt { Id = 1, Nev = "Harcos" },
                new Kaszt { Id = 2, Nev = "Mágus" },
                new Kaszt { Id = 3, Nev = "Íjász" },
                new Kaszt { Id = 4, Nev = "Tolvaj" },
                new Kaszt { Id = 5, Nev = "Pap" },
                new Kaszt { Id = 6, Nev = "Barbár" }
            );

            modelBuilder.Entity<Hos>().HasData(
                new Hos 
                { 
                    Id = 1, 
                    Nev = "Garrik, a Vaskezű", 
                    Szarmazas = "Északi-hegység", 
                    Szint = 12, 
                    KasztId = 1 
                },
                new Hos 
                { 
                    Id = 2, 
                    Nev = "Elara Fényszövő", 
                    Szarmazas = "Ezüst-erdő", 
                    Szint = 15, 
                    KasztId = 2 
                },
                new Hos 
                { 
                    Id = 3, 
                    Nev = "Legolas", 
                    Szarmazas = "Mirkwood", 
                    Szint = 18, 
                    KasztId = 3 
                },
                new Hos 
                { 
                    Id = 4, 
                    Nev = "Aragorn", 
                    Szarmazas = "Gondor", 
                    Szint = 20, 
                    KasztId = 1 
                },
                new Hos 
                { 
                    Id = 5, 
                    Nev = "Gandalf", 
                    Szarmazas = "Valinor", 
                    Szint = 25, 
                    KasztId = 2 
                },
                new Hos 
                { 
                    Id = 6, 
                    Nev = "Gimli", 
                    Szarmazas = "Moria", 
                    Szint = 17, 
                    KasztId = 1 
                },
                new Hos 
                { 
                    Id = 7, 
                    Nev = "Frodo", 
                    Szarmazas = "Shire", 
                    Szint = 10, 
                    KasztId = 4 
                },
                new Hos 
                { 
                    Id = 8, 
                    Nev = "Sam", 
                    Szarmazas = "Shire", 
                    Szint = 10, 
                    KasztId = 4 
                },
                new Hos 
                { 
                    Id = 9, 
                    Nev = "Merry", 
                    Szarmazas = "Shire", 
                    Szint = 10, 
                    KasztId = 4 
                },
                new Hos 
                { 
                    Id = 10, 
                    Nev = "Pippin", 
                    Szarmazas = "Shire", 
                    Szint = 10, 
                    KasztId = 4 
                }
            );
        }
    }
}
