using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public delegate System.Collections.Generic.KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    public class TestCollections<TKey, TValue>
    {
        private System.Collections.Generic.List<TKey> keyList;
        private System.Collections.Generic.List<string> stringList;
        private System.Collections.Generic.Dictionary<TKey, TValue> keyDict;
        private System.Collections.Generic.Dictionary<string, TValue> stringDict;
        private GenerateElement<TKey, TValue> GenElem;
        public static int ms = 0;
        public TestCollections(int count, GenerateElement<TKey, TValue> method)
        {
            keyList = new System.Collections.Generic.List<TKey>();
            stringList = new System.Collections.Generic.List<string>();
            keyDict = new Dictionary<TKey, TValue>();
            stringDict = new Dictionary<string, TValue>();
            GenElem = method;
            for(int i = 0; i < count; i++)
            {
                keyList.Add(GenElem(i).Key);
                stringList.Add(GenElem(i).Key.ToString());
                keyDict.Add(GenElem(i).Key, GenElem(i).Value);
                stringDict.Add(GenElem(i).Key.ToString(),GenElem(i).Value);
            }
        }
        public static KeyValuePair<string, Magazine> constructPair(int value)
        {
            ms++;
            string Key = (new DateTime(1000,1,1).AddDays(ms)).ToString();
            Magazine ValueMagazine = new Magazine("title", DateTime.Now.AddDays(ms), value);
            return new KeyValuePair<string, Magazine> ( Key, ValueMagazine);
        }
        public void searchTkeyList()
        {
            var first = keyList[0];
            var middle = keyList[keyList.Count / 2];
            var end = keyList[keyList.Count - 1];
            var nonExist = GenElem(keyList.Count + 1).Key;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            keyList.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            keyList.Contains(middle);
            sw.Stop();
            Console.WriteLine("Центральный элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            keyList.Contains(end);
            sw.Stop();
            Console.WriteLine("Последний элемент tKeyList: {0}", sw.Elapsed);

            sw.Restart();
            keyList.Contains(nonExist);
            sw.Stop();
            Console.WriteLine("Несуществующий элемент tKeyList: {0}", sw.Elapsed);

        }
        public void searchStringList()
        {
            var first = stringList[0];
            var middle = stringList[stringList.Count / 2];
            var end = stringList[stringList.Count - 1];
            var nonExist = GenElem(stringList.Count + 1).Key;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            stringList.Contains(first);
            sw.Stop();
            Console.WriteLine("Первый элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(middle);
            sw.Stop();
            Console.WriteLine("Центральный элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(end);
            sw.Stop();
            Console.WriteLine("Последний элемент stringList: {0}", sw.Elapsed);

            sw.Restart();
            stringList.Contains(nonExist.ToString());
            sw.Stop();
            Console.WriteLine("Несущетсвующий элемент stringList: {0}", sw.Elapsed);
        }
        public void searchTKeyDictionary()
        {
            TKey start = keyDict.ElementAt(0).Key;
            TKey middle = keyDict.ElementAt(keyDict.Count / 2).Key;
            TKey end = keyDict.ElementAt(keyDict.Count - 1).Key;
            TKey nonExist = GenElem(keyDict.Count + 1).Key;


            Console.WriteLine("Поиск элемента " + start + " в коллекции _dictionary<TKey,TValue> - ");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            keyDict.ContainsKey(start);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);

            sw.Restart();
            keyDict.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("Время поиска центрального элемента" + sw.Elapsed);

            sw.Restart();
            keyDict.ContainsKey(end);
            sw.Stop();
            Console.WriteLine("Время поиска последнего элемента" + sw.Elapsed);

            sw.Restart();
            keyDict.ContainsKey(nonExist);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);
        }
        public void searchStringDictionary()
        {
            string start = stringDict.ElementAt(0).Key;
            string middle = stringDict.ElementAt(stringDict.Count / 2).Key;
            string end = stringDict.ElementAt(stringDict.Count - 1).Key;
            TKey nonExist = GenElem(stringDict.Count + 1).Key;

            Console.WriteLine("Поиск элемента " + start + " в коллекции _dictionary<TKey,TValue> - ");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            stringDict.ContainsKey(start);
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);

            sw.Restart();
            stringDict.ContainsKey(middle);
            sw.Stop();
            Console.WriteLine("Время поиска центрального элемента" + sw.Elapsed);

            sw.Restart();
            stringDict.ContainsKey(end);
            sw.Stop();
            Console.WriteLine("Время поиска последнего элемента" + sw.Elapsed);

            sw.Restart();
            stringDict.ContainsKey(nonExist.ToString());
            sw.Stop();
            Console.WriteLine("Время поиска первого элемента" + sw.Elapsed);
        }
    }
    
}
