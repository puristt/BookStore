using BusinessLayer.ErrorHelper;
using DataAccessLayer.Repository.BookRepository;
using DataAccessLayer.Repository.PublisherRepository;
using Entities;
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
        private readonly IBookRepository _bookRepository;
        public PublisherService(IPublisherRepository publisherRepository, IBookRepository bookRepository)
        {
            _publisherRepository = publisherRepository;
            _bookRepository = bookRepository;
        }
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.GetById(id);
        }

        public GenericResults<Publisher> SaveModel(Publisher model)
        {
            var db_publisher = _publisherRepository.CheckByName(model.Name);
            GenericResults<Publisher> updateModel = new GenericResults<Publisher>();

            if (db_publisher != null)
            {
                updateModel.AddError(ErrorMessageCode.PublisherAlreadyExists, "Bu Yayınevi zaten sistemde Kayıtlı!");
                return updateModel;
            }

            updateModel.Model = this.PrepareEntity(model);
            int result = _publisherRepository.Save(updateModel.Model);
            if (result == 0)
            {
                updateModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir hata oluştu. Lütfen Tekrar Deneyiniz!");
            }
            return updateModel;
        }

        public IEnumerable<Publisher> SearchPublisherByName(string publisherName)
        {
            if(publisherName == null)
            {
                publisherName = "";
            }
            return _publisherRepository.SearchByName(publisherName);
        }
        public Publisher PrepareEntity(Publisher model)
        {
            var entity = _publisherRepository.GetById(model.Id) ?? new Publisher();

            entity.Name = model.Name;
            return entity;
        }

        public bool DeletePublisher(int id)
        {
            var bookCount = _bookRepository.CountByPublisherId(id);

            if (bookCount > 0)
                return false;

            int result = _publisherRepository.Delete(id);

            if (result == 0)
                return false;

            return true;
            
        }

        public IEnumerable<Publisher> SearchPublishersAlphabetically(string letter)
        {
            return _publisherRepository.SearchAlphabetically(letter);
        }
    }
}
