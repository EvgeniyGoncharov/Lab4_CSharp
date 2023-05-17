using System.Collections;
using System.Collections.Generic;

namespace lab2
{
    public delegate TKey KeySelector<TKey>(Magazine mg);
    public class Magazine : Edition, IRateAndCopy
    {
        private Frequency frequency;
        private List<Person> editors = new List<Person>();
        private List<Article> articles = new List<Article>();

        public Magazine(string bufftitle, Frequency buffrequency, DateTime buffdate, int buffnumber) : base(bufftitle, buffdate, buffnumber)
        {
            frequency = buffrequency;
        }
        public Magazine(string btitle, DateTime bdate, int bnumber) : base(btitle, bdate, bnumber)
        {
            title = btitle;
            date = bdate;
            number = bnumber;
        }
        public Magazine() : base("main page", DateTime.Today, 0)
        {      
            frequency = Frequency.Monthly;
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public Frequency periodicity
        {
            get { return frequency; }
            set { frequency = value; }
        }
        public System.DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public List<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }
        public List<Person> Editors
        {
            get { return editors; }
            set { editors = value; }
        }
        public double average_rating
        {
            get
            {
                double rating = 0;
                for (int i = 0; i < articles.Count; i++)
                {
                    rating += articles[i].Rating;
                }
                rating = rating / articles.Count;
                return rating;
            }
        }
        public double Rating
        {
            get { return average_rating; }
        }
        public bool this[Frequency period]
        {
            get
            {
                if (frequency == period) return true;
                else return false;
            }
        }
        public void AddArticles(List<Article> article)
        {
            for(int i=0; i<article.Count; i++)
            {
                articles.Add(article[i]);
            }
        }
        public void AddEditors(List<Person> editor)
        {
            for (int i = 0; i < editor.Count; i++)
            {
                editors.Add(editor[i]);
            }
        }
        public override string ToString()
        {
            string s1 = "";
            string s2 = "";
            for (int i = 0; i < Articles.Count; i++)
            {
                s1 += (Articles[i]).Title + "[" + (Articles[i]).Rating + "]\n";
            }
            for (int i = 0; i < editors.Count; i++)
            {
                s2 += (editors[i]).Name + " " + (editors[i]).Surname + "\n";
            }
            return title + "\nperiodicity: " + frequency.ToString() + "\ndate: " + date.ToString() + "\narticles: " + s1 + "editors: \n" + s2;
        }
        public virtual string ToShortString()
        {
            return title + "\nperiodicity: " + frequency.ToString() + " date: " + date.ToString() + "rating: " + average_rating.ToString();
        }
        public override object DeepCopy()
        {
            Magazine result = new Magazine();
            result = this;
            return result;
        }

        public Edition edit
        {
            get { return new Edition(Title, Date, Number); }
            set {
                    Title = value.Title;
                    Date = value.Date;
                    Number = value.Number; 
            }
        }
        public System.Collections.Generic.IEnumerable<Article> BetterThen(double rating)
        {
            for(int i = 0; i < Articles.Count; i++)
            {
                Article article = (Article)Articles[i];
                
               if (article.Rating > rating)
               {
                        yield return article;
               }          
                
            }
            
        }
        public System.Collections.Generic.IEnumerable<Article> ContainString(string buff)
        {
            foreach (Article article in Articles)
            {
                if (article.Title.Contains(buff))
                {
                    yield return article;
                }
            }
        }
        public void SortByArticles()
        {
            bool wrong = true;
            Article buff;
            while(wrong)
            {
                wrong = false;
                for (int i = 0; i < Articles.Count - 1; i++)
                {
                    if (string.Compare(Articles[i].Title, Articles[i + 1].Title) == 1)
                    {
                        buff = Articles[i];
                        Articles[i] = Articles[i + 1];
                        Articles[i + 1] = buff;
                        wrong = true;
                    }
                }
            }
        }
        public void SortByAuthors()
        {
            bool wrong = true;
            Article buff;
            while (wrong)
            {
                wrong = false;
                for (int i = 0; i < Articles.Count - 1; i++)
                {
                    if (string.Compare(Articles[i].Author.Surname, Articles[i + 1].Author.Surname) == 1)
                    {
                        buff = Articles[i];
                        Articles[i] = Articles[i + 1];
                        Articles[i + 1] = buff;
                        wrong = true;
                    }
                }
            }
        }
        public void SortByRating()
        {
            bool wrong = true;
            Article buff;
            while (wrong)
            {
                wrong = false;
                for (int i = 0; i < Articles.Count - 1; i++)
                {
                    if (Articles[i].Rating < Articles[i + 1].Rating)
                    {
                        buff = Articles[i];
                        Articles[i] = Articles[i + 1];
                        Articles[i + 1] = buff;
                        wrong = true;
                    }
                }
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Date, Number, frequency, editors, articles).GetHashCode();
        }
    }

}
