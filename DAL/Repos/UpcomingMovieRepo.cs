using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UpcomingMovieRepo : Repo, IRepo<UpcomingMovie, int, bool>
    {
        public bool Create(UpcomingMovie obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UpcomingMovie> Get()
        {
            throw new NotImplementedException();
        }

        public UpcomingMovie Get(int id)
        {
            throw new NotImplementedException();
        }

        public UpcomingMovie Read(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UpcomingMovie obj)
        {
            throw new NotImplementedException();
        }
    }
}
