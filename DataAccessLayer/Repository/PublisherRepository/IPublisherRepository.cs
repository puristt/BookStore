using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.PublisherRepository
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetAll();
    }
}
