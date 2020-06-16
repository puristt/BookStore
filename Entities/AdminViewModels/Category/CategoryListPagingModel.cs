using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Category
{
    public class CategoryListPagingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalRows { get; set; }

    }
}
