using SaladilloFit.Model;
using SaladilloFit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.ViewModels
{
    class UserPageViewModel : INotifyPropertyChanged
    {

        #region Constantes

        private const string MENSAJE_BIENVENIDO = "Bienvenido {0}";
        private const string FORMATO_ALTURA = "{0} cm";
        private const string FORMATO_PESO = "{0} Kg";

        #endregion

        #region Campos

        // Mensaje de bienvenida
        private string mensajeBienvenida = String.Empty;

        // DNI del usuario
        private string datoDni = String.Empty;

        // Horario del usuario
        private string datoHorario = String.Empty;

        // Objetivo del usuario
        private string datoObjetivo = String.Empty;

        // Edad del usuario
        private string datoEdad = String.Empty;

        // Altura del usuario
        private string datoAltura = String.Empty;

        // Peso del usuario
        private string datoPeso = String.Empty;

        // IMG del usuario
        private string datoImc = String.Empty;
        private Usuario usuario;

        #endregion

        #region Propiedades

        /// <summary>
        /// Mensaje de bienvenida.
        /// </summary>
        public string MensajeBienvenida
        {
            get
            {
                return mensajeBienvenida;
            }
            set
            {
                if (mensajeBienvenida != value)
                {
                    mensajeBienvenida = value;
                    OnPropertyChanged("MensajeBienvenida");
                }
            }
        }

        /// <summary>
        /// DNI del usuario.
        /// </summary>
        public string DatoDni
        {
            get
            {
                return datoDni;
            }
            set
            {
                if (datoDni != value)
                {
                    datoDni = value;
                    OnPropertyChanged("DatoDni");
                }
            }
        }

        /// <summary>
        /// Horario del usuario.
        /// </summary>
        public string DatoHorario
        {
            get
            {
                return datoHorario;
            }
            set
            {
                if (datoHorario != value)
                {
                    datoHorario = value;
                    OnPropertyChanged("DatoHorario");
                }
            }
        }

        /// <summary>
        /// Objetivo del usuario.
        /// </summary>
        public string DatoObjetivo
        {
            get
            {
                return datoObjetivo;
            }
            set
            {
                if (datoObjetivo != value)
                {
                    datoObjetivo = value;
                    OnPropertyChanged("DatoObjetivo");
                }
            }
        }

        /// <summary>
        /// Edad del usuario.
        /// </summary>
        public string DatoEdad
        {
            get
            {
                return datoEdad;
            }
            set
            {
                if (datoEdad != value)
                {
                    datoEdad = value;
                    OnPropertyChanged("DatoEdad");
                }
            }
        }

        /// <summary>
        /// Altura del usuario.
        /// </summary>
        public string DatoAltura
        {
            get
            {
                return datoAltura;
            }
            set
            {
                if (datoAltura != value)
                {
                    datoAltura = value;
                    OnPropertyChanged("DatoAltura");
                }
            }
        }

        /// <summary>
        /// Peso del usuario.
        /// </summary>
        public string DatoPeso
        {
            get
            {
                return datoPeso;
            }
            set
            {
                if (datoPeso != value)
                {
                    datoPeso = value;
                    OnPropertyChanged("DatoPeso");
                }
            }
        }

        /// <summary>
        /// IMC del usuario.
        /// </summary>
        public string DatoImc
        {
            get
            {
                return datoImc;
            }
            set
            {
                if (datoImc != value)
                {
                    datoImc = value;
                    OnPropertyChanged("DatoImc");
                }
            }
        }

        #endregion

        #region Constructor

        public UserPageViewModel(Usuario usuario)
        {
            this.usuario = usuario;
            IniciarValores();
        }

        #endregion

        #region Elementos Interfaz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Cierra la sesión y vuelve a la página de inicio.
        /// </summary>
        /// <remarks>
        /// Cierra la sesión y vuelve a la página de inicio, permitiendo cambiar de usuario
        /// </remarks>
        public void CambiarUsuario()
        {
            App.Current.MainPage = new MainPage();
        }

        /// <summary>
        /// Inicializa los valores del View Model.
        /// </summary>
        /// <remarks>
        /// Da valores iniciales a las propiedades del View Model a partir del usuario logueado.
        /// </remarks>
        public async void IniciarValores()
        {
            List<Horario> listaHorarios = new List<Horario>(await App.HorarioRepo.ObtenerHorarios());
            List<Objetivo> listaObjetivos = new List<Objetivo>(await App.ObjetivoRepo.ObtenerObjetivos());

            MensajeBienvenida = String.Format(MENSAJE_BIENVENIDO, usuario.Nombre);
            DatoDni = usuario.Dni;
            DatoHorario = listaHorarios.SingleOrDefault(t => t.Id == usuario.Horario).NombreHorario;
            DatoObjetivo = listaObjetivos.SingleOrDefault(t => t.Id == usuario.Objetivo).NombreObjetivo;
            DatoEdad = usuario.Edad.ToString();
            DatoAltura = String.Format(FORMATO_ALTURA, usuario.Altura);
            DatoPeso = String.Format(FORMATO_PESO, usuario.Peso);
            DatoImc = usuario.Imc.ToString();
        }

        #endregion
    }
}
