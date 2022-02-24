using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria Buscar(int id);
        void Crear(Categoria categoria);
        void Actualizar(Categoria categoria);
        void Eliminar(int id);

    }
}
