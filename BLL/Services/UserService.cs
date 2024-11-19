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
    public class UserService
    {
        public static List<UserDTO> Get()
        {

            var data = DataAccessFactory.UserData().Get();
            return Convert(data);

        }

        public static UserDTO Get(int id)
        {
            return Convert(DataAccessFactory.UserData().Get(id));
        }
        public static bool Create(UserDTO user)
        {
            var data = Convert(user);
            var res = DataAccessFactory.UserData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(UserDTO user)
        {
            var data = Convert(user);
            var res = DataAccessFactory.UserData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.UserData().Delete(id);
        }

        static List<UserDTO> Convert(List<User> users)
        {
            var data = new List<UserDTO>();
            foreach (var user in users)
            {
                data.Add(Convert(user));
            }
            return data;

        }
        static User Convert(UserDTO user)
        {
            return new User()
            {
                U_ID = user.U_ID,
                U_Name = user.U_Name,
                Password = user.Password,
                Name = user.Name,
                Type = user.Type,
                Email = user.Email
            };
        }
        static UserDTO Convert(User user)
        {
            return new UserDTO()
            {
                U_ID = user.U_ID,
                U_Name = user.U_Name,
                Password = user.Password,
                Name = user.Name,
                Type = user.Type,
                Email = user.Email
            };
        }
    }
}
