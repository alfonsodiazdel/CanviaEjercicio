using Domain.Models;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly IConfiguration _configuration;

        public LibroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Actualizar(Libro libro)
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_ACTUALIZAR_LIBRO";
                    cmd.Parameters.AddWithValue("@idLibro", libro.IdLibro);
                    cmd.Parameters.AddWithValue("@idCategoria", libro.IdCategoria);
                    cmd.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                    cmd.Parameters.AddWithValue("@paginas", libro.Paginas);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public Libro Buscar(int id)
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_BUSCAR_LIBRO";
                    cmd.Parameters.AddWithValue("@idLibro", id);

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Libro libro = new Libro
                        {
                            IdLibro = sdr.GetInt32("idLibro"),
                            IdCategoria = sdr.GetInt32("idCategoria"),
                            Descripcion = sdr.GetString("descripcion"),
                            Paginas = sdr.GetInt32("paginas"),
                            Fecha = sdr.GetDateTime("fecha"),
                            Estado = sdr.GetBoolean("estado"),
                            Categoria = sdr.GetString("categoria")
                        };
                        sdr.Close();
                        conn.Close();
                        return libro;
                    }
                }
            }
        }

        public void Crear(Libro libro)
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_CREAR_LIBRO";
                    cmd.Parameters.AddWithValue("@idCategoria", libro.IdCategoria);
                    cmd.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                    cmd.Parameters.AddWithValue("@paginas", libro.Paginas);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Eliminar(int id)
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_ELIMINAR_LIBRO";
                    cmd.Parameters.AddWithValue("@idLibro", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Libro> Listar()
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            List<Libro> lista = new List<Libro>();
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_LISTAR_LIBRO";

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Libro libro = new Libro
                            {
                                IdLibro = sdr.GetInt32("idLibro"),
                                IdCategoria = sdr.GetInt32("idCategoria"),
                                Descripcion = sdr.GetString("descripcion"),
                                Paginas = sdr.GetInt32("paginas"),
                                Fecha = sdr.GetDateTime("fecha"),
                                Estado = sdr.GetBoolean("estado"),
                                Categoria = sdr.GetString("categoria")
                            };
                            lista.Add(libro);
                        }
                    }
                }
            }
            return lista;
        }

        public List<Libro> ListarPorCategoria(int idCategoria)
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            List<Libro> lista = new List<Libro>();
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_FILTRAR_LIBRO_POR_CATEGORIA";
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Libro libro = new Libro
                            {
                                IdLibro = sdr.GetInt32("idLibro"),
                                IdCategoria = sdr.GetInt32("idCategoria"),
                                Descripcion = sdr.GetString("descripcion"),
                                Paginas = sdr.GetInt32("paginas"),
                                Fecha = sdr.GetDateTime("fecha"),
                                Estado = sdr.GetBoolean("estado"),
                                Categoria = sdr.GetString("categoria")
                            };
                            lista.Add(libro);
                        }
                    }
                }
            }
            return lista;
        }

    }
}
