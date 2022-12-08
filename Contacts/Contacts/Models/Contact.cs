using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        //public List<string> EmailAdresses { get; set; }
        //public List<string> PhoneNumbers { get; set; }

        public Contact()
        {
            //PhoneNumbers= new List<string>();
        }
    }
}