using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class ComparerArticles : IComparer<Article>
    {
        public int Compare(Article? x, Article? y)
        {
            if (x.Rating > y.Rating) return 1;
            if (x.Rating < y.Rating) return -1; 
            return 0;
        }
    }
}
