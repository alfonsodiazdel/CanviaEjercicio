using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanviaApi.Models
{
    public class ActualizarCategoriaRequest
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
