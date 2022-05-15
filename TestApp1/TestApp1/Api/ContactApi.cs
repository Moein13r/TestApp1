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
        private string Url = "";
        public async Task<List<Contact>> GetContactsByName(string name,CancellationToken tokenSource)
        {
            try
            {
                string uri = Url + "";
                string JsonContent = await Base.Get(uri);
                if (JsonContent == null)
                    return null;
                if (tokenSource.IsCancellationRequested)
                {
                    tokenSource.ThrowIfCancellationRequested();
                }
                List<Contact> items = DataConverter.JsonConverter<Contact[]>.JsonToObject(JsonContent).ToList();
                return items ?? new List<Contact>();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
