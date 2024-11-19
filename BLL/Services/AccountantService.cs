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
    public class AccountantService
    {
        public static List<AccountantDTO> Get()
        {

            var data = DataAccessFactory.AccountantData().Get();
            return Convert(data);

        }

        public static AccountantDTO Get(int id)
        {
            return Convert(DataAccessFactory.AccountantData().Get(id));
        }
        public static bool Create(AccountantDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.AccountantData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(AccountantDTO manager)
        {
            var data = Convert(manager);
            var res = DataAccessFactory.AccountantData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.AccountantData().Delete(id);
        }

        static List<AccountantDTO> Convert(List<Accountant> managers)
        {
            var data = new List<AccountantDTO>();
            foreach (var manager in managers)
            {
                data.Add(Convert(manager));
            }
            return data;

        }
        static Accountant Convert(AccountantDTO manager)
        {
            return new Accountant()
            {
                A_Id  =manager.A_Id,
                A_Name = manager.A_Name,
                Password = manager.Password,
                Name = manager.Name,
                Email = manager.Email
            };
        }
        static AccountantDTO Convert(Accountant manager)
        {
            return new AccountantDTO()
            {
                A_Id = manager.A_Id,
                A_Name = manager.A_Name,
                Password = manager.Password,
                Name = manager.Name,
                Email = manager.Email
            };
        }
    }
}
