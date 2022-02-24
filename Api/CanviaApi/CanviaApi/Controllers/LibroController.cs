using AutoMapper;
using CanviaApi.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CanviaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILibroService _libroService;
        public LibroController(ILibroService libroService, IMapper mapper)
        {
            _libroService = libroService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] PaginacionParametros paginacion)
        {
            try
            {
                var lista = _libroService.ListarLibros(paginacion);
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
                var libro = _libroService.BuscarLibro(id);
                return Ok(libro);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo realizar la busqueda.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NuevoLibroRequest request)
        {
            try
            {
                Libro libro = _mapper.Map<Libro>(request);
                _libroService.CrearLibro(libro);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo realizar la creación de libro.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActualizarLibroRequest request)
        {
            try
            {
                if (request.IdLibro != id)
                    return BadRequest();

                Libro libro = _mapper.Map<Libro>(request);
                _libroService.ActualizarLibro(libro);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo actualizar el libro.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _libroService.EliminarLibro(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo eliminar el libro.");
            }
        }

        [HttpGet("categoria/{id}")]
        public IActionResult GetByCategoria(int id)
        {
            try
            {
                var lista = _libroService.ListarPorCategoria(id);
                if (lista.Count == 0)
                    return StatusCode(202);
                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No se pudo realizar la busqueda.");
            }
        }

    }
}
