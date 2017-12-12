using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.Models
{
    class UsuarioObjetoLista
    {
        /// <summary>
        /// DNI del usuario.
        /// </summary>
        public string Dni { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Horario del usuario
        /// </summary>
        public string Horario { get; set; }

        /// <summary>
        /// Edad del usuario
        /// </summary>
        public int Edad { get; set; }

        /// <summary>
        /// Altura del usuario
        /// </summary>
        public int Altura { get; set; }

        /// <summary>
        /// Peso del usuario
        /// </summary>
        public float Peso { get; set; }

        /// <summary>
        /// IMC del usuario
        /// </summary>
        public float Imc { get; set; }

        /// <summary>
        /// Objetivo del usuario
        /// </summary>
        public string Objetivo { get; set; }

    }
}
