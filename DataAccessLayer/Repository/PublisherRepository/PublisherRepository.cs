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

        public Publisher CheckByName(string name)
        {
            var parameters = new { Name = name };
            return _repository.LoadData("spCheckPublisherExistanceByName", parameters).FirstOrDefault();
        }

        public int Delete(int id)
        {
            var parameters = new { Id = id };
            return _repository.SaveData<Publisher>("spDeletePublisher", parameters);
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _repository.LoadData("spGetAllPublishers");
        }

        public Publisher GetById(int id)
        {
            var parameters = new { PublisherId = id };
            return _repository.LoadData("spGetPublisher", parameters).FirstOrDefault();
        }

        public int Save(Publisher entity)
        {
            int result;
            if (entity.Id == default)
            {
                var parameters = new { entity.Name};
                result = _repository.SaveData<Author>("spInsertPublisher", parameters);
            }
            else
            {
                var parameters = new { entity.Id, entity.Name};
                result = _repository.SaveData<Author>("spUpdatePublisher", parameters);
            }

            return result;
        }

        public IEnumerable<Publisher> SearchByName(string publisherName)
        {
            var parameters = new { Name = publisherName };
            return _repository.LoadData("spSearchPublisherByName", parameters);
        }
    }
}
