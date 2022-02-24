using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly IConfiguration _configuration;

        public CategoriaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Actualizar(Categoria categoria)
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
                    cmd.CommandText = "SP_ACTUALIZAR_CATEGORIA";
                    cmd.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public Categoria Buscar(int id)
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
                    cmd.CommandText = "SP_BUSCAR_CATEGORIA";
                    cmd.Parameters.AddWithValue("@idCategoria", id);

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Categoria categoria = new Categoria
                        {
                            IdCategoria = sdr.GetInt32("idCategoria"),
                            Descripcion = sdr.GetString("descripcion"),
                            Fecha = sdr.GetDateTime("fecha"),
                            Estado = sdr.GetBoolean("estado")
                        };
                        sdr.Close();
                        conn.Close();
                        return categoria;
                    }
                }
            }
        }

        public void Crear(Categoria categoria)
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
                    cmd.CommandText = "SP_CREAR_CATEGORIA";
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
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
                    cmd.CommandText = "SP_ELIMINAR_CATEGORIA";
                    cmd.Parameters.AddWithValue("@idCategoria", id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public List<Categoria> Listar()
        {
            SqlConnection conn = null;
            string connectionString = _configuration.GetConnectionString("connection");
            List<Categoria> lista = new List<Categoria>();
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_LISTAR_CATEGORIA";

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Categoria categoria = new Categoria
                            {
                                IdCategoria = sdr.GetInt32("idCategoria"),
                                Descripcion = sdr.GetString("descripcion"),
                                Fecha = sdr.GetDateTime("fecha"),
                                Estado = sdr.GetBoolean("estado")
                            };
                            lista.Add(categoria);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
