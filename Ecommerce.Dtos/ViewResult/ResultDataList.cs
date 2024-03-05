using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Dtos.ViewResult
{
    public class ResultDataList<TEntity>
    {
        public List<TEntity> Entities {  get; set; }
        public int Count { get; set; }
        public ResultDataList()
        {
            Entities = new List<TEntity>();
        }
    }
}
