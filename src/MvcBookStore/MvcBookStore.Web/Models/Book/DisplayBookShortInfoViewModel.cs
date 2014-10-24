using System;

namespace MvcBookStore.Web.Models.Book
{
    public class DisplayBookShortInfoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public int QuantitySaled { get; set; }
        public string Image { get; set; }
    }
}