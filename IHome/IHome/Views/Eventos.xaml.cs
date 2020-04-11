using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IHome.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eventos : ContentPage
    {
        public Eventos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            lvEventos.ItemsSource = await App.Database.GetEventosAsync();
        }
    }
}