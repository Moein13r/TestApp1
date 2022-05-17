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
        ~MainPageViewModel()
        {
            Dispose();
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
        private readonly ContactApi Api;
        public async Task GetContactsByName(string text, System.Threading.CancellationToken ct)
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
    }
}