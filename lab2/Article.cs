using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        private Person author;
        private string title;
        private double rating;
        public Person Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public Article(Person buffauthor, string bufftitle, double buffrating)
        {
            author = buffauthor;
            title = bufftitle;
            rating = buffrating;
        }
        public Article()
        {
            author = new Person();
            title = "main page";
            rating = 0.0;
        }
        public override string ToString()
        {
            return author.ToStringshort()+ " " + title + " " + rating.ToString();
        }
        public object DeepCopy()
        {
            Article result = new Article(Author, Title, Rating);
            return result;
        }

        public int CompareTo(object? obj)
        {
            if(this.Title.Equals(((Article)obj).Title)) return 1;
            return 0;
        }

        public int Compare(Article? x, Article? y)
        {
            if (x.author.Surname.Equals((y.author.Surname))) return 1;
            return 0;
        }

    }
}
