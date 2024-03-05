using AutoMapper;
using Ecommerce.Application.Contracts;
using Ecommerce.Dtos.Author;
using Ecommerce.Dtos.ViewResult;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public  class AuthorServices : IAuthorServices
    {
        private readonly IAuthorRepository _AuhtorRepoesitory;
        private readonly IMapper _mapper;

        public AuthorServices(IAuthorRepository authorRepository, IMapper mapper)
        {
            _AuhtorRepoesitory = authorRepository;
            _mapper = mapper;
        }
        public async Task<ResultDataList<AuthorListViewModel>> GetAll()
        {
            try
            {
                var allAuthors = await _AuhtorRepoesitory.GetAllAsync();

                var authorViewModels = _mapper.Map<List<AuthorListViewModel>>(allAuthors);

                var resultDataList = new ResultDataList<AuthorListViewModel>
                {
                    Entities = authorViewModels,
                    Count = allAuthors.Count()
                };

                return resultDataList;
            }
            catch (Exception ex)
            {

                return new ResultDataList<AuthorListViewModel>
                {
                    Entities = null,
                    Count = 0,
                };
            }
        }

    }
}
