using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiLibros.Entidades
{

    [Table("Autor")]
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nombre {get;set;}

    }
}
