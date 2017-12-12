using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Model
{
    /// <summary>
    /// Representa un usuario de nuestra base de datos.
    /// </summary>
    /// <remarks>
    /// Representa un usuario de nuestra base de datos, por lo que es una tupla de la tabla
    /// usuario.
    /// </remarks>
    [Table("USUARIOS")]
    public class Usuario
    {
        /// <summary>
        /// Codigo con el que se identificará el usuario y podrá hacer login.
        /// </summary>
        [PrimaryKey, MaxLength(9)]
        public string Dni { get; set; }
        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        [NotNull, MaxLength(20)]
        public string Nombre { get; set; }
        /// <summary>
        /// Contraseña del usuario con la que podrá hacer login.
        /// </summary>
        [NotNull, MaxLength(9)]
        public string Password { get; set; }
        /// <summary>
        /// Horario del usuario.
        /// </summary>
        public int Horario { get; set; }
        /// <summary>
        /// Edad del usuario.
        /// </summary>
        public int Edad { get; set; }
        /// <summary>
        /// Altura del usuario.
        /// </summary>
        public int Altura { get; set; }
        /// <summary>
        /// Peso del usuario.
        /// </summary>
        public float Peso { get; set; }
        /// <summary>
        /// IMC del usuario.
        /// </summary>
        public float Imc { get; set; }
        /// <summary>
        /// Objetivo del usuario.
        /// </summary>
        public int Objetivo { get; set; }
        /// <summary>
        /// Tipo del usuario.
        /// </summary>
        [NotNull, MaxLength(7)]
        public string Tipo { get; set; }


    }
}
