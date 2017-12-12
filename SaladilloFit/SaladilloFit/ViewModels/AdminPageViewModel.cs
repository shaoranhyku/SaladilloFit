using SaladilloFit.Model;
using SaladilloFit.Models;
using SaladilloFit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SaladilloFit.ViewModels
{
    class AdminPageViewModel : INotifyPropertyChanged
    {

        #region Constantes

        private const string MENSAJE_ERROR_DATOSINVALIDOS = "Por favor, revise los datos";
        private const string MENSAJE_ERROR_USUARIOEXISTENTE = "El usuario ya existe";

        #endregion

        #region Campos

        // DNI del nuevo usuario
        private string datoDni = String.Empty;

        // Nombre del nuevo usuario
        private string datoNombre = String.Empty;

        // Lista de horarios que exiten
        private List<Horario> listaHorarios = new List<Horario>();

        // Índice del horario del nuevo usuario
        private int indiceHorario = -1;

        // Lista de objetivos que exiten
        private List<Objetivo> listaObjetivos = new List<Objetivo>();

        // Índice del objetivo del nuevo usuario
        private int indiceObjetivo = -1;

        // Edad del nuevo usuario
        private string datoEdad = String.Empty;

        // Altura del nuevo usuario
        private string datoAltura = String.Empty;

        // Peso del nuevo usuario
        private string datoPeso = String.Empty;

        // Mensaje de error
        private string mensajeError = String.Empty;

        // Lista de usuarios que existen
        private List<UsuarioObjetoLista> listaUsuarios = new List<UsuarioObjetoLista>();

        #endregion

        #region Propiedades

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
        /// Nombre del usuario.
        /// </summary>
        public string DatoNombre
        {
            get
            {
                return datoNombre;
            }
            set
            {
                if (datoNombre != value)
                {
                    datoNombre = value;
                    OnPropertyChanged("DatoNombre");
                }
            }
        }

        /// <summary>
        /// Indice del horario seleccionado.
        /// </summary>
        public int IndiceHorario
        {
            get
            {
                return indiceHorario;
            }
            set
            {
                if (indiceHorario != value)
                {
                    indiceHorario = value;
                    OnPropertyChanged("IndiceHorario");
                }
            }
        }

        /// <summary>
        /// Lista de horarios que existen.
        /// </summary>
        public List<Horario> ListaHorarios
        {
            get
            {
                return listaHorarios;
            }
            set
            {
                if (listaHorarios != value)
                {
                    listaHorarios = value;
                    OnPropertyChanged("ListaHorarios");
                }
            }
        }

        /// <summary>
        /// Indice del objetivo seleccionado.
        /// </summary>
        public int IndiceObjetivo
        {
            get
            {
                return indiceObjetivo;
            }
            set
            {
                if (indiceObjetivo != value)
                {
                    indiceObjetivo = value;
                    OnPropertyChanged("IndiceObjetivo");
                }
            }
        }

        /// <summary>
        /// Lista de objetivos que existen.
        /// </summary>
        public List<Objetivo> ListaObjetivos
        {
            get
            {
                return listaObjetivos;
            }
            set
            {
                if (listaObjetivos != value)
                {
                    listaObjetivos = value;
                    OnPropertyChanged("ListaObjetivos");
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
        /// Mensaje de error.
        /// </summary>
        public string MensajeError
        {
            get
            {
                return mensajeError;
            }
            set
            {
                if (mensajeError != value)
                {
                    mensajeError = value;
                    OnPropertyChanged("MensajeError");
                }
            }
        }

        /// <summary>
        /// Lista de usuarios que existen.
        /// </summary>
        public List<UsuarioObjetoLista> ListaUsuarios
        {
            get
            {
                return listaUsuarios;
            }
            set
            {
                if (listaUsuarios != value)
                {
                    listaUsuarios = value;
                    OnPropertyChanged("ListaUsuarios");
                }
            }
        }


        #endregion

        #region Constructor

        public AdminPageViewModel()
        {
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
            ListaHorarios = new List<Horario>(await App.HorarioRepo.ObtenerHorarios());
            ListaObjetivos = new List<Objetivo>(await App.ObjetivoRepo.ObtenerObjetivos());
            List<Usuario> listaUsuariosTabla = new List<Usuario>(await App.UsuarioRepo.ObtenerUsuarios());
            List<UsuarioObjetoLista> nuevaListaUsuarios = new List<UsuarioObjetoLista>();

            foreach(Usuario usuarioTabla in listaUsuariosTabla)
            {
                if (usuarioTabla.Tipo.Equals("USUARIO"))
                {
                    nuevaListaUsuarios.Add(new UsuarioObjetoLista()
                    {
                        Dni = usuarioTabla.Dni,
                        Nombre = usuarioTabla.Nombre,
                        Horario = ListaHorarios.SingleOrDefault(t => t.Id == usuarioTabla.Horario).NombreHorario,
                        Edad = usuarioTabla.Edad,
                        Altura = usuarioTabla.Altura,
                        Peso = usuarioTabla.Peso,
                        Imc = usuarioTabla.Imc,
                        Objetivo = ListaObjetivos.SingleOrDefault(t => t.Id == usuarioTabla.Objetivo).NombreObjetivo
                    });
                }
            }
            ListaUsuarios = nuevaListaUsuarios;
        }

        public async void AgregarUsuario(Page actualPage)
        {
            int edad = 0;
            int altura = 0;
            float peso = 0;
            List<Usuario> listaUsuariosTabla = new List<Usuario>(await App.UsuarioRepo.ObtenerUsuarios());

            if (String.IsNullOrEmpty(DatoDni) ||
                String.IsNullOrEmpty(DatoNombre) ||
                IndiceHorario == -1 ||
                !int.TryParse(DatoEdad, out edad) ||
                !int.TryParse(DatoAltura, out altura) ||
                !float.TryParse(DatoPeso, out peso) ||
                IndiceObjetivo == -1 ||
                DatoDni.Length != 9)
            {
                MensajeError = MENSAJE_ERROR_DATOSINVALIDOS;
            }
            else
            {
                
                if(listaUsuariosTabla.SingleOrDefault(t => t.Dni.Equals(DatoDni)) != null)
                {
                    MensajeError = MENSAJE_ERROR_USUARIOEXISTENTE;
                }
                else
                {
                    await App.UsuarioRepo.AgregarUsuario(DatoDni, DatoNombre, IndiceHorario, edad, altura, peso, IndiceObjetivo, "USUARIO");
                    actualPage.DisplayAlert("Usuario añadido correctamente.", "", "Aceptar");
                    App.Current.MainPage = new AdminPage();
                }
            }
        }

        #endregion
    }
}
