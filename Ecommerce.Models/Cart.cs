using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Cart
    {
        //[Key]
        public int Id { get; set; }
        //[ForeignKey("order")]
        //public int OrderId { get; set; }
        //public Order order { get; set; }
        //[ForeignKey("product")]
        //public int ProductId { get; set; }
        public List<int> booksids { get; set; }
        //public int Quantity { get; set; }

        public Cart()
        {
            booksids = new List<int>();
        }


    }
}
