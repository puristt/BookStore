using BusinessLayer.ErrorHelper;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.PublisherService
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();
        IEnumerable<Publisher> SearchPublisherByName(string publisherName);
        Publisher GetPublisherById(int id);
        GenericResults<Publisher> SaveModel(Publisher model);
        bool DeletePublisher(int id);
        IEnumerable<Publisher> SearchPublishersAlphabetically(string letter);
    }
}
