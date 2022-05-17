using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp1.ViewModels;
using Xamarin.Forms;

namespace TestApp1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel Vm;
        public MainPage()
        {
            InitializeComponent();
            Vm = new MainPageViewModel();
            BindingContext = Vm;
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (cts != null)
            {
                cts.Cancel();
                ct = cts.Token;
            }
            cts = new System.Threading.CancellationTokenSource();
            ct = cts.Token;
            await Vm.GetContactsByName(SearchBar.Text, ct);
        }
        System.Threading.CancellationToken ct;
        System.Threading.CancellationTokenSource cts;
        private async void SearchContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
                ct = cts.Token;
            }
            cts = new System.Threading.CancellationTokenSource();
            ct = cts.Token;
            await Vm.GetContactsByName(SearchBar.Text,ct);
        }
    }
}
