using DataAccessLayer.Repository.PublisherRepository;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.PublisherService
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }
    }
}
