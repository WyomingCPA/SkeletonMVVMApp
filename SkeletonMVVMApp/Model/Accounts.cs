using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonMVVMApp.Model
{
    public class Accounts
    {
        private bool m_value;

        public bool Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                RaisePropertyChanged("Value");
            }
        }

        public string Id
        {
            get;
            set;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public string FireFoxProfile { get; set; }

        public Accounts(string email, string password, string country, string firefoxprofile)
        {
            Email = email;
            Password = password;
            FireFoxProfile = firefoxprofile;
            Country = country;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
