using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Entities.AdminViewModels.Book
{
    public class BookRelatedDropDownListModel
    {
        public MultiSelectList Categories { get; set; }
        public MultiSelectList Publishers { get; set; }
        public MultiSelectList Authors { get; set; }

    }
}
