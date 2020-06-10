using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ErrorHelper
{
    public class GenericResults<T> where T : class
    {
        public List<ErrorModel> Errors { get; set; }
        public T Model { get; set; }


        public GenericResults()
        {
            Errors = new List<ErrorModel>();
        }

        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorModel { Code = code, Message = message });
        }
    }
}
