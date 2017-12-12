using SaladilloFit.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SaladilloFit
{
    public partial class App : Application
    {

        public static UsuarioRepository UsuarioRepo { get; set; }
        public static HorarioRepository HorarioRepo { get; set; }
        public static ObjetivoRepository ObjetivoRepo { get; set; }

        public App(string filename)
        {
            InitializeComponent();

            UsuarioRepo = new UsuarioRepository(filename);
            HorarioRepo = new HorarioRepository(filename);
            ObjetivoRepo = new ObjetivoRepository(filename);

        MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
