using SaladilloFit.Model;
using SaladilloFit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaladilloFit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private UserPageViewModel viewModel;

        public UserPage(Usuario usuario)
        {
            InitializeComponent();

            viewModel = new UserPageViewModel(usuario);

            BindingContext = viewModel;

            btnCambiarUsuario.Clicked += BtnCambiarUsuario_Clicked;
        }

        private void BtnCambiarUsuario_Clicked(object sender, EventArgs e)
        {
            viewModel.CambiarUsuario();
        }
    }
}