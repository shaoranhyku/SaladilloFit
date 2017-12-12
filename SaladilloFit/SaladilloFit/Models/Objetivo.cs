using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Models
{
    /// <summary>
    /// Representa un objetivo de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa un objetivo de nuestra base de datos, por lo que es una tupla de la tabla
    /// objetivo.
    /// </remarks>
    [Table("OBJETIVOS")]
    public class Objetivo
    {
        /// <summary>
        /// ID del objetivo.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        /// <summary>
        /// Nombre del horario.
        /// </summary>
        [NotNull, Unique, MaxLength(20)]
        public string NombreObjetivo { get; set; }


        override
        public string ToString()
        {
            return NombreObjetivo;
        }
    }
}
