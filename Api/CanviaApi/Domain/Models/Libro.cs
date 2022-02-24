using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Paginas { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public string Categoria { get; set; }
    }
}
