using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab2
{
    public delegate void MagazinesChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);
    public class MagazineCollection<TKey>
    {
        public TKey[] TKeyCollection;
        private KeySelector<TKey> _keySelector;
        private Dictionary<TKey, Magazine> magazineDict = new Dictionary<TKey, Magazine>();
        public string collectionTitle;
        public MagazineCollection(KeySelector<TKey> keySelector)
        {
            _keySelector = keySelector;
        }
        public string MagazineDict
        {
            get;
            set;
        }
        public event MagazinesChangedHandler<TKey> MagazinesChanged;
        public MagazinesChangedEventArgs<TKey> PropertyName;
        public string CollectionTitle
        {
            get { return collectionTitle; }
            set { collectionTitle = value; }
        }
        public bool Replace(Magazine mold, Magazine mnew)
        {
            bool exist = false;
            TKey key = default;
            foreach (KeyValuePair<TKey, Magazine> pair in magazineDict)
            {
                if (EqualityComparer<Magazine>.Default.Equals(pair.Value, mold))
                {
                    key = pair.Key;
                    exist = true;
                    break;
                }
            }
            if (exist)
            {   
                MagazinesChanged(Replace, PropertyName);
                magazineDict.Remove(key);
                magazineDict.Add(key, mnew);
            }
            return exist;
        }
        public static string GetKey(Magazine magazine)
        {
            return magazine.Number.ToString();
        }
        public void AddDefaults()
        {
            /*PropertyName = new MagazinesChangedEventArgs<TKey>(collectionTitle, "AddDefaults", Update.Add,  );*/
            MagazinesChanged(AddDefaults, PropertyName);
            Magazine magazine1 = new Magazine("журнал нэйм 1", Frequency.Weekly, new DateTime(2023, 5, 5), 100);
            Magazine magazine2 = new Magazine("журнал нэйм 2", Frequency.Weekly, new DateTime(2023, 7, 7), 200);

            magazineDict.Add(_keySelector(magazine1), magazine1);
            magazineDict.Add(_keySelector(magazine2), magazine2);
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<TKey, Magazine> item in magazineDict)
            {
                builder.AppendLine("---------------------");
                builder.AppendFormat("\nНомер журнала:{0} \nНазвание: {1}\n рейтинг: {2}\n", item.Value.Number, item.Value.Title, item.Value.Rating);

                builder.Append("Редакторы:\n");
                foreach (var editor in item.Value.Editors)
                    builder.AppendLine(editor.ToString());

                builder.Append("Статьи:\n");
                foreach (var article in item.Value.Articles)
                    builder.AppendLine(article.ToString());
            }
            return builder.ToString();

        }
        public void AddMagazines(List<Magazine> magazine)
        {
            
            foreach (var item in magazine)
            {
                MagazinesChanged(AddMagazines, PropertyName);
                magazineDict.Add(_keySelector(item), item);
            }
        }
        public string ToShortString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (KeyValuePair<TKey, Magazine> item in magazineDict)
            {
                builder.AppendLine("---------------------");
                builder.AppendFormat("\nДата:{0}\nНомер журнала:{1} \nНазвание: {2}\n рейтинг журнала: {3}\n рейтинг статей: {4}\n", item.Value.Date, item.Value.Number, item.Value.Title, item.Value.Rating, item.Value.average_rating);

                builder.AppendFormat("Редакторы: {0}\n", item.Value.Editors.Count);

                builder.AppendFormat("Статьи:{0}\n", item.Value.Articles.Count);
            }
            return builder.ToString();
        }
        public double MaxRating
        {
            get
            {
                double maxRating = 0;
                List<double> values = new();
                foreach (var item in magazineDict)
                {
                    values.Add(item.Value.average_rating);
                }
                return Enumerable.Max(values);
            }
        }
        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return magazineDict.Where(magazine => magazine.Value.periodicity == value);
        }
        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> RateOut
        {
            get
            {
                return magazineDict.GroupBy(magazine => magazine.Value.periodicity);
            }
        }
    }
}
