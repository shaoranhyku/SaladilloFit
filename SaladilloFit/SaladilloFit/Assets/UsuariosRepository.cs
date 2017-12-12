using SaladilloFit.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    /// <summary>
    /// Repositorio que nos permite conectar con la tabla usuario de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// usuario.
    /// </remarks>
    public class UsuarioRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public UsuarioRepository(string dbPath)
        {

            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Usuario>().Wait();
        }

        /// <summary>
        /// Permite añadir un usuario a la tabla usuarios de la base de datos.
        /// </summary>
        /// <remarks>
        /// Realiza una conexión con la tabla usuarios de nuestra base de datos,
        /// añadiendo una tupla con los parametros dados.
        /// </remarks>
        /// <param name="dni"> DNI del usuario. </param>
        /// <param name="nombre"> Nombre del usuario. </param>
        /// <param name="horario"> Horario del usuario. </param>
        /// <param name="edad"> Edad del usuario. </param>
        /// <param name="altura"> Altura del usuario. </param>
        /// <param name="peso"> Peso del usuario. </param>
        /// <param name="objetivo"> Objetivo del usuario. </param>
        /// <param name="tipo"> Tipo de usuario. </param>
        /// <returns>Tarea de añadir la tupla a la base de datos.</returns>
        public async Task AgregarUsuario(string dni, string nombre, int horario, int edad, int altura, float peso, int objetivo, string tipo)
        {
            int result = 0;
            try
            {
                result = await conn.InsertAsync(new Usuario { Dni = dni,
                    Nombre = nombre,
                    Password = dni,
                    Horario = horario,
                    Edad = edad,
                    Altura = altura,
                    Peso = peso,
                    Imc = peso / ((altura / 100) * (altura / 100)),
                    Objetivo = objetivo,
                    Tipo = tipo
                });

                StatusMessage = string.Format("{0} record(s) added.",result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add. Error: {1}", ex.Message);
            }

        }

        /// <summary>
        /// Permite obtener una lista con todos los usuarios de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla usuario de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos usuario.
        /// </remarks>
        /// <returns>
        /// Lista de usuarios de la base de datos.
        /// </returns>
        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios;
            try
            {
                listaUsuarios = await conn.Table<Usuario>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaUsuarios = new List<Usuario>();
            }

            return listaUsuarios;

        }
    }
}
