using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookStore.Repostoriy
{
    public class AuthorsRepository : IBookStoreRepostoriycs<Authors>
    {
        IList<Authors> Authors;
        public AuthorsRepository()
        {
            Authors = new List<Authors>()
            {
                new Authors{Id=55,FullName="mohammed naser"}
                , new Authors{Id=12,FullName="Ali naser"}

            };
        }



        public void Add(Authors entity)
        {
            entity.Id = Authors.Max(b => b.Id) + 1;
            Authors.Add(entity);
        }

        public void Delete(int id)
        {
            var x = Authors.SingleOrDefault(x => x.Id == id);
            Authors.Remove(x);
        }

        public Authors Find(int id)
        {
            var x = Authors.FirstOrDefault(x => x.Id == id);
            return x;
        }

        public IList<Authors> List()
        {
            return Authors;
        }

        public void Update(Authors entity, int id)
        {
            var x = Find(id);
            x.Id = entity.Id;
            x.FullName = entity.FullName;
        }
    }
}
