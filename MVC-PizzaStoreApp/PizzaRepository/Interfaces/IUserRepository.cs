using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaDbData;

namespace PizzaRepository.Interfaces
{
    interface IUserRepository
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        void AddNewUser(User objUser);
        User EditUserDetail(int id);
    }
}
