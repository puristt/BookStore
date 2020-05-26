using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.AdminViewModels.Book
{
    public class BookFilterModel
    {
        public MultiSelectList Categories { get; set; }
        public SelectList Publishers { get; set; }
        public SelectList Authors { get; set; }

    }
}
