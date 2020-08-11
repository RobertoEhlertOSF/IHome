using IHome.Data;
using IHome.Models;
using IHome.Services;
using IHome.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IHome
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControleEquipamentos : ContentPage
    {
        public ControleEquipamentos()
        {
            InitializeComponent();
        }

        private void GoToEquipamentos(object sender, EventArgs eventArgs)
        {
            Navigation.PushModalAsync(new Equipamentos());           
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetEquipamentosAsync();
        } 

        private async void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            var changed = ((SwitchCell)sender).BindingContext as Equipamento;
            RegistrarEvento(changed.ID, e.Value);
            await ServiceIO.ActionIO(changed.Pino, e.Value);
            await App.Database.SaveEquipamentoAsync(changed);
        }

        public async void RegistrarEvento (int idEquip, bool sw)
        {
            if (sw)
            {
                DateTime ? valor = null;
                await App.Database.SaveEventosAsync(new Evento
                {
                    StartDateTime = DateTime.Now,
                    IDEquipamento = idEquip,
                    EndDateTime = valor.GetValueOrDefault()
                });
            }   
            else
            {
                var evento = await App.Database.GetEventoByEquipamentoID(idEquip);
                evento.EndDateTime = DateTime.Now;
                await App.Database.SaveEventosAsync(evento);
            }
        }

        private void BtLigarTudo_Clicked(object sender, EventArgs e)
        {

        }

        private void BtDesligarTudo_Clicked(object sender, EventArgs e)
        {

        }
    }
}