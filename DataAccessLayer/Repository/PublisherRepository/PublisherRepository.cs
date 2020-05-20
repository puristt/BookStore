using DataAccessLayer.DatabaseManager;
using Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.PublisherRepository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IDapperRepository<Publisher> _repository;

        public PublisherRepository(IDapperRepository<Publisher> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Publisher> GetAll()
        {
            return _repository.LoadData("spGetAllPublishers");
        }
    }
}
