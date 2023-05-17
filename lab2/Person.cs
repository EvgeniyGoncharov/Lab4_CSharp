using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Person
    {
        private string name;
        private string surname;
        System.DateTime date;
        public Person(string buffname, string buffsurname, System.DateTime buffdate)
        {
            name = buffname;
            surname = buffsurname;
            date = buffdate;
        }
        public Person()
        {
            name = "Ivan";
            surname = "Ivanov";
            date = System.DateTime.Today;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public System.DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Year
        {
            get { return date.Year; }
            set { date = new DateTime(value, date.Month, date.Day); }
        }
        public override string ToString()
        {
            return name + ' ' + surname + ' ' + date.ToString();
        }
        virtual public string ToStringshort()
        {
            return name + ' ' + surname;
        }
        public override bool Equals(object obj)
        {
            if (!name.Equals(((Person)obj).Name) || !surname.Equals(((Person)obj).Surname) || !date.Equals(((Person)obj).Date)){
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name,Surname,Date);
        }
        public static bool operator ==(Person a, Person b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Person a, Person b)
        {
            return !a.Equals(b);
        }
        public Person DeepCopy()
        {
            return new Person(Name, Surname, Date);
        }
    }
}
