using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Book
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(350)]
        public string? Description { get; set; }
        public int Price { get; set; }
        [ForeignKey("Author")]
        public string  AuthorName { get; set; }
    }
}
