using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Books
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public string Description { get; set; }

        public string Category { get; set; }
        [Required]
        public int LanguageId { get; set; }
        // public List<string> MultiLanguage { get; set; }

        // public LanguageEnum MyProperty { get; set; }

        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Language? Language { get; set; }


    }
}
