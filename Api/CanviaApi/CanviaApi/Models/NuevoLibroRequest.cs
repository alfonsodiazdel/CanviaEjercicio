using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanviaApi.Models
{
    public class NuevoLibroRequest
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Paginas { get; set; }
    }
}
