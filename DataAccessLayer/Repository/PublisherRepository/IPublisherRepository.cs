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
        IEnumerable<Publisher> SearchByName(string publisherName);
        Publisher GetById(int id);
        Publisher CheckByName(string name);
        int Save(Publisher entity);
        int Delete(int id);
    }
}
