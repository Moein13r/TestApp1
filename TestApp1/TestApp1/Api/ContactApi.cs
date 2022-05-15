using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp1.Models;

namespace TestApp1.Api
{
    public class ContactApi
    {
        private Base Base = new Base();
        private string Url = "https://localhost:7020/api/ContactsApi/";
        public async Task<List<Contact>> GetContactsByName(string name,CancellationToken tokenSource)
        {
            try
            {
                string uri = Url + $"GetContactsByname?name={name}";
                string JsonContent = await Base.Get(uri);
                if (JsonContent == null)
                    return null;                    
                List<Contact> items = DataConverter.JsonConverter<Contact[]>.JsonToObject(JsonContent).ToList();
                tokenSource.ThrowIfCancellationRequested();
                return items ?? new List<Contact>();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<List<Contact>> GetAllContacts(CancellationToken tokenSource)
        {
            try
            {
                string uri = Url + $"GetAllContacts";
                string JsonContent = await Base.Get(uri);
                if (JsonContent == null)
                    return null;
                List<Contact> items = DataConverter.JsonConverter<Contact[]>.JsonToObject(JsonContent).ToList();
                tokenSource.ThrowIfCancellationRequested();
                return items ?? new List<Contact>();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
