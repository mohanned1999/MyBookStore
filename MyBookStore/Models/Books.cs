﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public Authors Authors { get; set; }

    }
}
