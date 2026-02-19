using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Heroes.Models
{
    public class Kaszt
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Hos> Hosok { get; set; }
    }

    public class Hos
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Szarmazas { get; set; }
        public int Szint { get; set; }
        
        public int KasztId { get; set; }
        public Kaszt? Kaszt { get; set; }
    }
}
