using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public enum Update
    {
        Add,
        Replace,
        Property
    }
    public class Edition : INotifyPropertyChanged
    {
        protected string title;
        protected DateTime date;
        protected int number;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set 
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Date"));
                date = value; 
            }
        }
        public int Number
        {
            get { return number; }
            set 
            { 
                if(value < 0)
                {   
                    throw new ArgumentException("Номер должен быть неотрицательным");
                }
                else 
                {
                    PropertyChanged(Number, Property);
                    number = value; 
                }                
            }
        }
        public Edition(string bufftitle, DateTime buffdate, int buffnumber)
        {
            Title = bufftitle;
            Date = buffdate;
            Number = buffnumber;
        }

  

        public Edition()
        {
            Title = "None";
            Date = DateTime.Today;
            Number = 0;
        }
        public virtual object DeepCopy() {
            Edition result = new Edition();
            result.Title = Title;  
            result.Date = Date;
            result.Number = Number;
            return result;
        }
        public override bool Equals(object? obj)
        {   
            return Title.Equals(((Edition)obj).Title) || !Number.Equals(((Edition)obj).Number) || !Date.Equals(((Edition)obj).Date);
        }
        public static bool operator ==(Edition a, Edition b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Edition a, Edition b)
        {
            return !a.Equals(b);
        }
        public override string ToString()
        {
            string result = "";
            result = Title + "\nДата: " + Date + "\nНомер: " + Number;
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Date, Number).GetHashCode();
        }
    }
}
