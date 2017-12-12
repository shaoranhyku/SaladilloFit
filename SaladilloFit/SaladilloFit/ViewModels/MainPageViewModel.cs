using SaladilloFit.Model;
using SaladilloFit.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaladilloFit.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        #region Constantes

        private const string MENSAJE_ERROR_USUARIOCONTRA = "Debe introducir Usuario y Contraseña(9 caracteres).";
        private const string MENSAJE_ERROR_USUARIO = "Debe introducir Usuario(9 caracteres).";
        private const string MENSAJE_ERROR_CONTRA = "Debe introducir Contraseña(9 caracteres).";
        private const string MENSAJE_ERROR_USUARIO_NOALTA = "El Usuario no está dado de Alta.";
        private const string MENSAJE_ERROR_CONTRA_NOCORRECTA = "La Contraseña no es correcta.";

        #endregion

        #region Campos

        // Nombre del usuario
        private string nombreUsuario = String.Empty;

        // Contraseña del usuario
        private string contraUsuario = String.Empty;

        // Mensaje de error
        private string mensajeError = String.Empty;

        #endregion

        #region Propiedades

        /// <summary>
        /// Nombre del usuario.
        /// </summary>
        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }
            set
            {
                if (nombreUsuario != value)
                {
                    if (value != null && value.Length <= 9)
                    {
                        nombreUsuario = value;
                    }
                    OnPropertyChanged("NombreUsuario");
                }
            }
        }

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string ContraUsuario
        {
            get
            {
                return contraUsuario;
            }
            set
            {
                if (contraUsuario != value)
                {
                    if (value != null && value.Length <= 9)
                    {
                        contraUsuario = value;
                    }
                    OnPropertyChanged("ContraUsuario");
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
        /// Intenta iniciar sesión con los datos introducidos.
        /// </summary>
        /// <remarks>
        /// Comprueba que los datos introducidos cumplen las condiciones dadas,
        /// que el usuario está en la base de datos, e inicia sesión abriendo una nueva página
        /// dependiendo del tipo de usuario.
        /// </remarks>
        public async void EntrarAsync()
        {
            if(NombreUsuario.Length < 9 && ContraUsuario.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_USUARIOCONTRA;
            }
            else if(NombreUsuario.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_USUARIO;
            }else if(ContraUsuario.Length < 9)
            {
                MensajeError = MENSAJE_ERROR_CONTRA;
            }
            else
            {
                List<Usuario> listaUsuarios = new List<Usuario>(await App.UsuarioRepo.ObtenerUsuarios());

                Usuario usuarioIdentificado = listaUsuarios.SingleOrDefault(t => t.Dni.Equals(NombreUsuario));

                if (usuarioIdentificado == null)
                {
                    MensajeError = MENSAJE_ERROR_USUARIO_NOALTA;
                }
                else if (!usuarioIdentificado.Password.Equals(ContraUsuario))
                {
                    MensajeError = MENSAJE_ERROR_CONTRA_NOCORRECTA;
                }
                else
                {
                    if (usuarioIdentificado.Tipo.Equals("USUARIO"))
                    {  
                        App.Current.MainPage = new UserPage(usuarioIdentificado);
                    }
                    else if (usuarioIdentificado.Tipo.Equals("GERENTE"))
                    {
                        App.Current.MainPage = new AdminPage();
                    }
                }
            }

            


        }

        #endregion

    }
}
