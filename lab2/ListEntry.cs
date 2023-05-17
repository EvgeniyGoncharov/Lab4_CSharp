using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class ListEntry
    {
        public string collectionTitle;
        public Update type;
        public string property;
        public string key;
        public string CollectionTitle
        {
            get { return collectionTitle; }
            set { collectionTitle = value; }
        }
        public Update Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Property
        {
            get { return property; }
            set { property = value; }
        }
        public string Keys
        {
            get { return key; }
            set { key = value; }
        }
        public ListEntry(string bcollectionTitle, Update btype, string bproperty, string bkey)
        {
            CollectionTitle = bcollectionTitle;
            Property = bproperty;
            Keys = bkey;
            Type = btype;
        }

        public string ToString()
        {
            return collectionTitle + ' ' + type + ' ' + property + ' ' + key;
        }
    }
}
