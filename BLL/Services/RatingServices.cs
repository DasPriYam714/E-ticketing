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
    public class RatingServices
    {
        public static List<RatingDTO> Get()
        {

            var data = DataAccessFactory.RatingData().Get();
            return Convert(data);

        }
        public static RatingDTO Get(int id)
        {
            return Convert(DataAccessFactory.RatingData().Get(id));
        }
        public static bool Create(RatingDTO admin)
        {
            var data = Convert(admin);
            var res = DataAccessFactory.RatingData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(RatingDTO admin)
        {
            var data = Convert(admin);
            var res = DataAccessFactory.RatingData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.AdminData().Delete(id);
        }

        static List<RatingDTO> Convert(List<Rating> admins)
        {
            var data = new List<RatingDTO>();
            foreach (var admin in admins)
            {
                data.Add(Convert(admin));
            }
            return data;

        }
        static Rating Convert(RatingDTO admin)
        {
            return new Rating()
            {
                R_Id = admin.R_Id,
                ratings = admin.ratings,
                U_ID = admin.U_ID,
                M_Id = admin.M_Id
            };
        }
        static RatingDTO Convert(Rating admin)
        {
            return new RatingDTO()
            {
                R_Id = admin.R_Id,
                ratings = admin.ratings,
                U_ID = admin.U_ID,
                M_Id = admin.M_Id
            };
        }
    }
}
