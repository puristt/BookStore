using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Book
{
    public class SearchModel
    {
        /// <summary>
        /// Filtrede aranacak basım yılı başlangıç tarihi(aralık türünden)
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Filterede aranacak basım yılı bitiş tarihi(aralık türünden)
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Filtrelenirken aranacak kategoriler. Bir kitap birden fazla kategori içinde olabilir.
        /// array olarak tutulduktan sonra ',' ile ayırarak tek satır bir string verisi haline getirilecek.
        /// </summary>
        public string[] CategoryIds { get; set; }
        /// <summary>
        /// Filtrede aranacak yayınevi
        /// </summary>
        public string[] PublisherIds { get; set; }
        /// <summary>
        /// Filtrede aranacak yazar
        /// </summary>
        public string[] AuthorIds { get; set; }
        /// <summary>
        /// Filtrede aranacak kitap adı
        /// </summary>
        public string BookName { get; set; }
    }
}
