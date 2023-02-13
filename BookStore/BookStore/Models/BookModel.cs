using BookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter book title ")]

        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter author name for book ")]

        public string Author { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter category ")]

        public string Category { get; set; }
        [Required]
        public int LanguageId { get; set; }
        // public List<string> MultiLanguage { get; set; }

        // public LanguageEnum MyProperty { get; set; }


        [Required(ErrorMessage = "Please enter total pages for book ")]
        [Display(Name = "Total Pages for a book")]
        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string? Language { get; set; }

    }
}
