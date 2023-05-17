using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Listener
    {
        private List<ListEntry> listEntries = new List<ListEntry>();
        public void magazinesChanged(object source, MagazinesChangedEventArgs<string> args)
        {
            listEntries.Add(new ListEntry(args.Title, args.Action, args.Property, args.Key));
        }
        public string ToString()
        {
            string result = "";
            foreach(ListEntry entry in listEntries)
            {
                result += entry.ToString() + '\n';
            }
            return result;
        }
    }
}
