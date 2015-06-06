using ContactList.Interfaces;
using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactList.Views
{
    public partial class ListaContatos : ContentPage
    {
        public ListaContatos()
        {
            InitializeComponent();

            lstContatos.ItemsSource = this.getList();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lstContatos.ItemSelected += lstContatos_ItemSelected;
        }

        async void lstContatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var contact = (Contato)e.SelectedItem;

            await Navigation.PushModalAsync(new NavigationPage(new ContactDetails(contact)));

            ((ListView)sender).SelectedItem = null;

        }

        List<Contato> getList()
        {
            return new List<Contato>{
                new Contato()
                {
                    Name="Leonardo",
                    Phone="+55 (31) 1111-1111", 
                    LastContact = DateTime.Now,
                    Email = "leosoareslima@outlook.com",
                    History = "Sou eu mesmo, me conheço desde neném",
                    ProfileUrlImage = "Tiger1.jpg",
                    ListUrlImages = new List<string>(){"background.jpg","Nature.jpg","Tiger2.jpg", "Tiger1.jpg"}
                },
                new Contato()
                {
                    Name="Rafael",
                    Phone="+55 (31) 1111-1111", 
                    LastContact = new DateTime(2015, 06, 03),
                    Email = "rafaelrmour2@hotmail.com",
                    History = "Parceiro de desenvolvimento desde 2009 e agora juntos no xamarin",
                    ProfileUrlImage = "Tiger2.jpg",
                    ListUrlImages = new List<string>(){"Nature.jpg","Tiger1.jpg","Tiger2.jpg", "background.jpg"}
                },
                new Contato()
                {
                    Name="Albert",
                    Phone="+55 (31) 2222-2222",
                    LastContact = new DateTime(2015, 06, 02),
                    Email = "tanure@live.com",
                    History="Albert grande parceiro de desenvolvimento conosco no xamarin",
                    ProfileUrlImage="Nature.jpg",
                    ListUrlImages= new List<string>(){"Tiger1.jpg", "Tiger2.jpg", "Nature,jpg", "background.jpg"}
                },
            };
        }
    }
}
