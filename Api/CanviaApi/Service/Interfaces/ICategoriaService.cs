using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Service.Models;

namespace Service.Interfaces
{
    public interface ICategoriaService
    {
        List<Categoria> ListarCategorias(PaginacionParametros paginacion);
        Categoria BuscarCategoria(int id);
        void CrearCategoria(Categoria categoria);
        void ActualizarCategoria(Categoria categoria);
        void EliminarCategoria(int id);

    }
}
