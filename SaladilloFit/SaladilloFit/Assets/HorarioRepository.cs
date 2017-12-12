using SaladilloFit.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Assets
{
    /// <summary>
    /// Repositorio que nos permite conectar con la tabla horarios de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// horarios.
    /// </remarks>
    public class HorarioRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public HorarioRepository(string dbPath)
        {

            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Horario>().Wait();
        }

        /// <summary>
        /// Permite obtener una lista con todos los horarios de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla horarios de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos horario.
        /// </remarks>
        /// <returns>
        /// Lista de horarios de la base de datos.
        /// </returns>
        public async Task<List<Horario>> ObtenerHorarios()
        {
            List<Horario> listaHorarios;
            try
            {
                listaHorarios = await conn.Table<Horario>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaHorarios = new List<Horario>();
            }

            return listaHorarios;

        }
    }
}
