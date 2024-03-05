using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Book : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string? Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public  Author Author { get; set; }
    }
}
