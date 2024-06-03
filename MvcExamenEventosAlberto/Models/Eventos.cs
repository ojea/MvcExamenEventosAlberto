using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcExamenEventosAlberto.Models
{
    public class Eventos
    {
        public int IdEvento { get; set; }

        public string Nombre { get; set; }

        public string Artista { get; set; }

        public int IdCategoria { get; set; }

        public string Imagen { get; set; }
    }
}
