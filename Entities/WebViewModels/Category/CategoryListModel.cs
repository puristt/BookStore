using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.WebViewModels.Category
{
    public class CategoryListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int BookCount { get; set; }
    }
}
