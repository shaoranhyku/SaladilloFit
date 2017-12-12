using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Models
{
    /// <summary>
    /// Representa un horario de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa un horario de nuestra base de datos, por lo que es una tupla de la tabla
    /// horario.
    /// </remarks>
    [Table("HORARIOS")]
    public class Horario
    {
        /// <summary>
        /// ID del horario.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del horario.
        /// </summary>
        [NotNull, Unique, MaxLength(15)]
        public string NombreHorario { get; set; }

        override
        public string ToString()
        {
            return NombreHorario;
        }
    }
}
