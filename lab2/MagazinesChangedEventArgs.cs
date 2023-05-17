using System.Data;

namespace lab2
{
    public class MagazinesChangedEventArgs<TKey> : EventArgs
    {
        public string title;
        public string property;
        public Update action;
        public TKey key;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Property
        { /*открытое автореализуемое свойство типа string с названием свойства
        класса Magazine, которое является источником изменения данных
        элемента; для событий, порожденных добавлением или заменой
        элемента, значение свойства - пустая строка*/

        get { return property; }
            set 
            { 
  
                property = value; 
            }
        }
        public Update Action
        {
            get { return action; }
            set { action = value; }
        }
        public TKey Key
        {
            get { return key; }
            set { key = value; }
        }
        public MagazinesChangedEventArgs(string btitle, string bproperty, Update baction, TKey bkey)
        {
            Title = btitle;
            Property = bproperty;
            Action = baction;
            Key = bkey;
        }
        public string ToString() 
        {
            return Title + ' '+ Property + ' '+ Action+ ' ' + Key;
        }
    }
}