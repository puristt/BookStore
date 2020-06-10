using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ErrorHelper
{
    public class ErrorModel
    {
        public ErrorMessageCode Code { get; set; }
        public string Message { get; set; }
    }
}
