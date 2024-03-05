using Ecommerc.MVC.Data;
using Ecommerce.Application.Contracts;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class AuthorReposatory : Repository<Author, int>, IAuthorRepository
    {

        public AuthorReposatory(ApplicationDbContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
