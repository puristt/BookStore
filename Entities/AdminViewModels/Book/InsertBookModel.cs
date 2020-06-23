using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AdminViewModels.Book
{
    public class InsertBookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Range(1, 9999, ErrorMessage = "Fiyat {1} ve {2} aralığında olmalıdır!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string ISBN13 { get; set; }
        [Range(1, 9999, ErrorMessage = "Sayfa sayısı {1} 'den küçük değer alamaz!")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Page { get; set; }
        [Range(0, 9999, ErrorMessage = "Stok {0} 'ın altında değer alamaz!")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int PublisherId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int AuthorId { get; set; }
        public string[] CategoryIds { get; set; }

    }
}
