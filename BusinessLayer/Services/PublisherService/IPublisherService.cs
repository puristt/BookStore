using BusinessLayer.ErrorHelper;
using Entities.AdminViewModels.Publisher;
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
        IEnumerable<PublisherListModel> GetAllWithPaging(out int totalItemCount);
        IEnumerable<Publisher> SearchPublisherByName(string publisherName);
        IEnumerable<PublisherListModel> SearchPublisherByNameWithPaging(string searchText, int pageNumber, int pageSize, out int totalItemCount);
        Publisher GetPublisherById(int id);
        GenericResults<Publisher> SaveModel(Publisher model);
        bool DeletePublisher(int id);
        IEnumerable<Publisher> SearchPublishersAlphabetically(string letter);
    }
}
