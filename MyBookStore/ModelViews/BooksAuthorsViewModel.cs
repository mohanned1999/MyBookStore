using Microsoft.AspNetCore.Http;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.ModelViews
{
    public class BooksAuthorsViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [MinLength(5)]
        public string Title { get; set; }

        [Required]
        [StringLength(120,MinimumLength =5)]
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public List<Authors> Authors { get; set; }
        public string ImgUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
