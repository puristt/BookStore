using BusinessLayer.ErrorHelper;
using DataAccessLayer.DatabaseManager;
using DataAccessLayer.Repository.BookRepository;
using DataAccessLayer.Repository.PublisherRepository;
using Entities;
using Entities.AdminViewModels.Publisher;
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
        private readonly IDapperRepository<Publisher> _dapperRepository;
        public PublisherService(IPublisherRepository publisherRepository, IBookRepository bookRepository, IDapperRepository<Publisher> dapperRepository)
        {
            _publisherRepository = publisherRepository;
            _bookRepository = bookRepository;
            _dapperRepository = dapperRepository;
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
            GenericResults<Publisher> genericModel = new GenericResults<Publisher>();

            if (db_publisher != null)
            {
                genericModel.AddError(ErrorMessageCode.PublisherAlreadyExists, "Bu Yayınevi zaten sistemde Kayıtlı!");
                return genericModel;
            }

            genericModel.Model = this.PrepareEntity(model);
            int result = _publisherRepository.Save(genericModel.Model);

            if (result == 0)
            {
                genericModel.AddError(ErrorMessageCode.SomethingWentWrong, "Bir hata oluştu. Lütfen Tekrar Deneyiniz!");
            }
            return genericModel;
        }

        public IEnumerable<Publisher> SearchPublisherByName(string publisherName)
        {
            if (publisherName == null)
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

        public IEnumerable<PublisherListModel> SearchPublisherByNameWithPaging(string searchText, int pageNumber, int pageSize, out int totalItemCount)
        {
            if (searchText == null)
            {
                searchText = "";
            }
            var parameters = new { Name = searchText, PageNumber = pageNumber, PageSize = pageSize };

            var result = _dapperRepository.LoadData<PublisherListModel>("spSearchPublisherByNameWithPaging", parameters);

            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }

        public IEnumerable<PublisherListModel> GetAllWithPaging(out int totalItemCount)
        {
            var result = _dapperRepository.LoadData<PublisherListModel>("spGetAllPublishersPaging");
            totalItemCount = result.Any() ? result.First().TotalRows : 0;

            return result;
        }
    }
}
