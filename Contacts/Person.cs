using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    public class Person : INotifyPropertyChanged
    {

        private string _name;
            private string _surname;
            private string _city;
            private string _profileImage;
            public Person(string name, string surname, string city)
            {
                this.Name = name;
                this.Surname = surname;
                this.City = city;
           
            }
            public string Name
            {
                get => _name;
                set { _name = value;
                NotifyPropertyChanged("Name");
                }
            }
            public string Surname
            {
                get => _surname;
                set { _surname = value;
                NotifyPropertyChanged("Surname");
                }
            }
            public string City
            {
                get => _city;
                set { _city = value;
                NotifyPropertyChanged("City");
                }
            }
        public string ProfileImage
        {
            get => _profileImage;
            set
            {
                _profileImage = value;
                NotifyPropertyChanged("ProfileImage");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string FullName
        {
            get => Name + " " + Surname;
        }
       
    }
}
