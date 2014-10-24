using System;
using System.ComponentModel.DataAnnotations;

namespace MvcBookStore.Web.Models.Book
{
    public class EditorBookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "*")]
        [MaxLength(60, ErrorMessage = "Max: 60")]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "*")]
        [MaxLength(13, ErrorMessage = "Max: 13")]
        public string ISBN { get; set; }
    }
}