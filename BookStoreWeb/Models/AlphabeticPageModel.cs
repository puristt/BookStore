using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class AlphabeticPageModel<T> where T : class
    {
        public AlphabeticPageModel()
        {
            ItemList = new List<T>();
        }
        public IEnumerable<T> ItemList { get; set; }
        public IList<string> Alphabet
        {
            get
            {
                var alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList();
                alphabet.Insert(0, "Tümü");
                return alphabet;
            }
        }
    }
}