using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovieService
    {
        public static List<MovieDTO> Get()
        {

            var data = DataAccessFactory.MovieData().Get();
            return Convert(data);

        }

        public static MovieDTO Get(int id)
        {
            return Convert(DataAccessFactory.MovieData().Get(id));
        }
        public static bool Create(MovieDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.MovieData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(MovieDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.MovieData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.MovieData().Delete(id);
        }

        static List<MovieDTO> Convert(List<Movie> managers)
        {
            var data = new List<MovieDTO>();
            foreach (var manager in managers)
            {
                data.Add(Convert(manager));
            }
            return data;

        }
        static Movie Convert(MovieDTO manager)
        {
            return new Movie()
            {
                M_Id = manager.M_Id,
                M_Name = manager.M_Name,
                Time = manager.Time,
                Showtime = manager.Showtime
            };
        }
        static MovieDTO Convert(Movie manager)
        {
            return new MovieDTO()
            {
                M_Id = manager.M_Id,
                M_Name = manager.M_Name,
                Time = manager.Time,
                Showtime = manager.Showtime
            };
        }
    }
}
