using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public enum LanguageEnum
    {
        [Display(Name="Marathi Language")]
        Marathi,
        [Display(Name = "Hindi Language")]
        Hindi,
        [Display(Name = "English Language")]
        English
    }
}
