using System;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Xamarin.Essentials;
using SQLite;
using Newtonsoft.Json;

namespace Contacts.Models
{
    public class InsultController
    {
        public async Task SendInsult(string number, string name)
        {
            HttpClient client = new HttpClient();
            var insult = await client.GetStringAsync("https://insult.mattbas.org/api/insult.txt?who=" + name);
            number = number.Replace(" ", "");
            try
            {
                var message = new SmsMessage(insult, new[] { number });
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                 //Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                 //Other error has occurred.
            }
        }
    }
}