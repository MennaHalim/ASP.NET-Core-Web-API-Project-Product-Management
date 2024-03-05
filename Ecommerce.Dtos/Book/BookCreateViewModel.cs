using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Dtos.Book
{
    public class BookCreateViewModel
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string? Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
    }

}
