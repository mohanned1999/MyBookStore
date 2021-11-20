using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Repostoriy
{
    public class BookRepostoriy : IBookStoreRepostoriycs<Books>
    {
        List<Books> books;
        public BookRepostoriy()
        {
            books = new List<Books>()
            {
                new Books
                {
                    Id=1,
                    Title="asp .net",
                    Description="is high level book",
                    ImgUrl="unnamed.jpg",
                    Authors=new Authors(){Id=55 }
                    

                },
                 new Books
                {
                    Id=2,
                    Title="asp core .net",
                    Description="is low level book",
                    ImgUrl="css-javascript-html-usage-monitor-closeup-function-source-code-abstract-technology-background-software-website-144744928.jpg",
                      Authors=new Authors(){Id=321}

        }

            };
        }
        public void Add(Books entity)
        {
            entity.Id = books.Max(b => b.Id)+1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
          
            books.Remove(books.SingleOrDefault(x => x.Id == id));
        }

        public Books Find(int id)
        {
            var x = books.FirstOrDefault(x => x.Id == id);
            return x;
        }

        public IList<Books> List()
        {
            return books;
        }

        public void Update(Books entity,int id)
        {
            var x = books.SingleOrDefault(x => x.Id == id);
            x.Title = entity.Title;
            x.Description = entity.Description;
            x.Authors = entity.Authors;
            x.ImgUrl = entity.ImgUrl;
        }
    }
}
