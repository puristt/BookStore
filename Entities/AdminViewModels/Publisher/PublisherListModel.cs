using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Publisher
{
    public class PublisherListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalRows { get; set; } // Sayfalama için dönecek toplam kayıt sayısı
    }
}
