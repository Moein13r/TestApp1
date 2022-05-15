using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApp1.Api;
using TestApp1.Models;

namespace TestApp1.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Api = new ContactApi();
            Contacts = new List<Contact>() { new Contact { Name = "Test", PhoneNumber = "09332182965" }, new Contact { Name = "Test", PhoneNumber = "09332182965" }, new Contact { Name = "Test", PhoneNumber = "09332182965" }, new Contact { Name = "Test", PhoneNumber = "09332182965" } };
        }
        private List<Contact> _Contacts;
        public List<Contact> Contacts
        {
            get
            {
                return _Contacts;
            }
            set
            {
                _Contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }
        System.Threading.CancellationToken ct;
        System.Threading.CancellationTokenSource cts;
        private readonly ContactApi Api;
        public async void GetContactsByName(string text)
        {
            if (cts != null)
            {
                cts.Cancel();
                ct = cts.Token;
            }
            cts = new System.Threading.CancellationTokenSource();
            ct = cts.Token;
            await Task.Run(async () =>
            {
                try
                {
                    var items = await Api.GetContactsByName(text, ct);
                    if (items != null)
                    {
                        Contacts = items;
                    }                    
                }
                catch (OperationCanceledException e)
                {
                }
            }
            , ct);
        }
    }
}