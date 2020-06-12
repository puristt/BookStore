using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreWeb.Models
{
    public class PublisherPageViewModel
    {
        public PublisherPageViewModel()
        {
            Publishers = new List<Publisher>();
        }
        public IEnumerable<Publisher> Publishers { get; set; }
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