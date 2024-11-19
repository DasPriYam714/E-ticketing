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
    public class ManagerService
    {
        public static List<ManagerDTO> Get()
        {

            var data = DataAccessFactory.ManagerData().Get();
            return Convert(data);

        }

        public static ManagerDTO Get(int id)
        {
            return Convert(DataAccessFactory.ManagerData().Get(id));
        }
        public static bool Create(ManagerDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.ManagerData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(ManagerDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.ManagerData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ManagerData().Delete(id);
        }

        static List<ManagerDTO> Convert(List<Manager> managers)
        {
            var data = new List<ManagerDTO>();
            foreach (var manager in managers)
            {
                data.Add(Convert(manager));
            }
            return data;

        }
        static Manager Convert(ManagerDTO manager)
        {
            return new Manager()
            {
                Manager_Id = manager.Manager_Id,
                Manager_Name = manager.Manager_Name,
                Movie = manager.Movie,
                Movie_Time = manager.Movie_Time
            };
        }
        static ManagerDTO Convert(Manager manager)
        {
            return new ManagerDTO()
            {
                Manager_Id = manager.Manager_Id,
                Manager_Name = manager.Manager_Name,
                Movie = manager.Movie,
                Movie_Time = manager.Movie_Time
            };
        }
    }
}
