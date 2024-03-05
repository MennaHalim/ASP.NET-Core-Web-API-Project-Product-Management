﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
    public interface IBookRepository : IRepository<Book, int>
    {
        Task<Book> GetByIdWithAuthorAsync(int id);
        Task<IQueryable<Book>> GetAllWithAuthorAsync();

    }
}
