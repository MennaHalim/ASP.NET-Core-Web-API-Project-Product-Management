using Ecommerce.Dtos.Author;
using Ecommerce.Dtos.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IAuthorServices 
    {
        Task<ResultDataList<AuthorListViewModel>> GetAll();

    }
}
