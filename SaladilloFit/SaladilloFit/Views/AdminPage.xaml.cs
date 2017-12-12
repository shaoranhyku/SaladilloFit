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
    public partial class AdminPage : ContentPage
    {
        private AdminPageViewModel viewModel;

        public AdminPage()
        {
            InitializeComponent();

            viewModel = new AdminPageViewModel();

            BindingContext = viewModel;

            btnCambiarUsuario.Clicked += BtnCambiarUsuario_Clicked;
            btnAgregar.Clicked += BtnAgregar_Clicked;
        }

        private void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            viewModel.AgregarUsuario(this);
        }

        private void BtnCambiarUsuario_Clicked(object sender, EventArgs e)
        {
            viewModel.CambiarUsuario();
        }
    }
}