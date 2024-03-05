using AutoMapper;
using Ecommerce.Application.Contracts;
using Ecommerce.Dtos.Book;
using Ecommerce.Dtos.ViewResult;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IBookService
    {
        Task<ResultView<BookCreateViewModel>> Create(BookCreateViewModel book);

        Task<ResultView<BookEditViewModel>> HardDelete(int book);
        Task<ResultDataList<BookListViewModel>> GetAllPagination(int items, int pagenumber);
        Task<BookDetailsViewModel> GetOne(int ID);
        Task<ResultView<BookEditViewModel>> Edit(BookEditViewModel book);
        Task<BookEditViewModel> GetEditViewModel(int ID);


    }
}
