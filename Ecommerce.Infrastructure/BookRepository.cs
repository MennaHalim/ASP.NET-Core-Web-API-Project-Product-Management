using Ecommerc.MVC.Data;
using Ecommerce.Application.Contracts;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class BookRepository : Repository<Book, int> , IBookRepository
    {
        public BookRepository(ApplicationDbContext ecommerceContext) : base(ecommerceContext)
        {
            
        }
        public async Task<Book> GetByIdWithAuthorAsync(int id)
        {
            return await _ecommerceContext.Set<Book>()
                                 .Include(b => b.Author)
                                 .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IQueryable<Book>> GetAllWithAuthorAsync()
        {
            return await Task.FromResult(_ecommerceContext.Books.Include(b => b.Author).AsNoTracking());
        }
    }
}
