using BookReader.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReader.Domain.Enum;

namespace BookReader.Domain.ViewModel
{
    public class BookViewModel
    {
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? AuthorUrl { get; set; }
        public decimal Price { get; set; }
        public DateTime? Created { get; set; }
        public Genre Genre { get; set; }
    }
}
