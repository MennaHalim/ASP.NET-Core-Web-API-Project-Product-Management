using AutoMapper;
using Ecommerce.Application.Contracts;
using Ecommerce.Dtos.Book;
using Ecommerce.Dtos.ViewResult;
using Ecommerce.Models;

namespace Ecommerce.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResultView<BookCreateViewModel>> Create(BookCreateViewModel book)
        {
            var Query = (await _bookRepository.GetAllAsync()); 
          
                var Prd = _mapper.Map<Book>(book);
                var Newbook = await _bookRepository.CreateAsync(Prd);
                await _bookRepository.SaveChangesAsync();
                var bookDto = _mapper.Map<BookCreateViewModel>(Newbook);
                return new ResultView<BookCreateViewModel> { Entity = bookDto, IsSuccess = true, Message = "Created Successfully" };

        }

        public async Task<ResultView<BookEditViewModel>> HardDelete(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdAsync(id);
                if (book == null)
                {
                    return new ResultView<BookEditViewModel> { IsSuccess = false, Message = "Book not found." };
                }

                _bookRepository.DeleteAsync(book);
                await _bookRepository.SaveChangesAsync();

                return new ResultView<BookEditViewModel> { IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<BookEditViewModel> { IsSuccess = false, Message = ex.Message };
            }
        }


        public async Task<ResultDataList<BookListViewModel>> GetAllPagination(int items, int pagenumber) //10 , 3 -- 20 30
        {
            var AllData = (await _bookRepository.GetAllWithAuthorAsync());
            var books = AllData.Skip(items * (pagenumber - 1)).Take(items)
                                              .Select(b => new BookListViewModel()
                                              {
                                                  Id = b.Id,
                                                  Title = b.Title,
                                                  AuthorName = b.Author.Name
                                              }).ToList();
            ResultDataList<BookListViewModel> resultDataList = new ResultDataList<BookListViewModel>();
            resultDataList.Entities = books;
            resultDataList.Count = AllData.Count();
            return resultDataList;
        }

        public async Task<BookDetailsViewModel> GetOne(int ID)
        {
            var book = await _bookRepository.GetByIdWithAuthorAsync(ID);

            var REturnPrd = _mapper.Map<BookDetailsViewModel>(book);
            return REturnPrd;
        }


        public async Task<ResultView<BookEditViewModel>> Edit(BookEditViewModel book)
        {
            try
            {
                var existingBook = await _bookRepository.GetByIdAsync(book.Id);
                if (existingBook == null)
                    return new ResultView<BookEditViewModel> { IsSuccess = false, Message = "Book not found" };

                _mapper.Map(book, existingBook);
                await _bookRepository.UpdateAsync(existingBook);
                await _bookRepository.SaveChangesAsync();

                return new ResultView<BookEditViewModel> { Entity = book, IsSuccess = true, Message = "Book updated successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<BookEditViewModel> { IsSuccess = false, Message = $"Error updating book: {ex.Message}" };
            }
        }

        public async Task<BookEditViewModel> GetEditViewModel(int ID)
        {
            var prd = await _bookRepository.GetByIdAsync(ID);
            var editViewModel = _mapper.Map<BookEditViewModel>(prd);
            return editViewModel;
        }
    }
}
