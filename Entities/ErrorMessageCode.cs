using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum ErrorMessageCode
    {
        SomethingWentWrong = 400,
        CategoryALreadyExists = 101,
        AuthorAlreadyExists = 102,
        PublisherAlreadyExists = 103,
        BookAlreadyExists = 104,
    }
}
