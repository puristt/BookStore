using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataModels
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string Name { get; set; }
    }
}
