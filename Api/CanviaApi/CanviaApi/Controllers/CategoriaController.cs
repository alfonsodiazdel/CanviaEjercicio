using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;
using AutoMapper;
using CanviaApi.Models;
using Domain.Models;
using Service.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Get([FromQuery] PaginacionParametros paginacion)
        {
            try
            {
                var lista = _categoriaService.ListarCategorias(paginacion);
                if (lista.Count == 0) 
                    return StatusCode(202);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo realizar la busqueda.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var categoria = _categoriaService.BuscarCategoria(id);
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo realizar la busqueda.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NuevaCategoriaRequest request)
        {
            try
            {
                Categoria categoria = _mapper.Map<Categoria>(request);
                _categoriaService.CrearCategoria(categoria);
                return Ok();
            }catch(Exception e)
            {
                return StatusCode(500, "No se pudo realizar la creación de categoria.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarCategoriaRequest request)
        {
            try
            {
                if (request.IdCategoria != id) 
                    return BadRequest();

                Categoria categoria = _mapper.Map<Categoria>(request);
                _categoriaService.ActualizarCategoria(categoria);
                return Ok();
            }catch(Exception e)
            {
                return StatusCode(500, "No se pudo actualizar la categoría.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoriaService.EliminarCategoria(id);
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, "No se pudo eliminar la categoría.");
            }
        }
    }
}
