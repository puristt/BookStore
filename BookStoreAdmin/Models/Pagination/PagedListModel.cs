using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreAdmin.Models.Pagination
{
    public class PagedListModel<T> where T : class
    {
        public PagedListModel()
        {
            CurrentList = new List<T>();
        }
        public IEnumerable<T> CurrentList { get; set; }
        public int PageSize
        {
            get { return _pageSize < 1 ? 10 : _pageSize; }
            set { _pageSize = value; }
        }
        private int _pageSize;
        public int CurrentPageNumber
        {
            get
            {
                return _currentPageNumber;
            }
            set
            {
                _currentPageNumber = value;
            }
        }
        private int _currentPageNumber;
        public int FirstItemInCurrentPage
        {
            get
            {
                return (CurrentPageNumber * PageSize) - 9;
            }
        }
        public int LastItemInCurrentPage
        {
            get
            {
                return (CurrentPageNumber * PageSize);
            }
        }
        public int TotalItemCount { get; set; }
        public int TotalPage
        {
            get
            {
                return (TotalItemCount / PageSize);
            }
        }

    }
}