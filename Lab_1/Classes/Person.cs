using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Classes
{
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person()
        {
            this.name = "";
            this.surname = "";
            this.birthday = DateTime.Now;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Surname
        {
            get => surname;
            set => surname = value;
        }
        public DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }

        public int BirthYear
        {
            get => birthday.Year;
            set => birthday = new DateTime(value, birthday.Month, birthday.Day);
        }

        public override string ToString()
        {
            return "\n - Person name: " + name + "\n - Person surname: " + surname + "\n - DateOfbirthday: " + birthday;
        }

        public virtual string ToShortString()
        {
            return "\nPerson name: " + name + "\nPerson surname: " + surname;
        }
    }
}
