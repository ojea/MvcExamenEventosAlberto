using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcExamenEventosAlberto.Models
{
    public class CategoriasEvento
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
