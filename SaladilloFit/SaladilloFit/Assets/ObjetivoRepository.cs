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
    /// Repositorio que nos permite conectar con la tabla objetivos de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Esta clase contiene metodos para conectarse con nuestra base de datos y acceder a la tabla
    /// objetivos.
    /// </remarks>
    public class ObjetivoRepository
    {
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public ObjetivoRepository(string dbPath)
        {

            conn = new SQLiteAsyncConnection(dbPath);

            conn.CreateTableAsync<Objetivo>().Wait();
        }

        /// <summary>
        /// Permite obtener una lista con todos los objetivos de la base de datos.
        /// </summary>
        /// <remarks>
        /// Se conecta con la tabla objetivos de la base de datos y obtiene todas las tuplas transformadas
        /// a objetos objetivo.
        /// </remarks>
        /// <returns>
        /// Lista de objetivos de la base de datos.
        /// </returns>
        public async Task<List<Objetivo>> ObtenerObjetivos()
        {
            List<Objetivo> listaObjetivos;
            try
            {
                listaObjetivos = await conn.Table<Objetivo>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", e.Message);
                listaObjetivos = new List<Objetivo>();
            }

            return listaObjetivos;

        }
    }
}
