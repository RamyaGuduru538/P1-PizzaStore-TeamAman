using PizzaDbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRepository.Classes
{
   public class UserRepository : Interfaces.IUserRepository
    {
        private PizzaDb db;
        public UserRepository(PizzaDb db)
        {
            this.db = db;
        }
        public void AddNewUser(User objuser)
        {

        }

        public IEnumerable<User> GetAllUser()
        {
            return db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
             var data = db.Users.Where(d => d.id == id).FirstOrDefault();
             return data;
            }
            else
            {
                return null;
            }
        }
        public void DeleteUserById(int id)
        {
            var logindata = db.Logins.Where(s => s.user_id == id).FirstOrDefault();
            db.Logins.Remove(logindata);
            Save();
            var user = db.Users.Find(id)
;
            if (user != null)
            {
                db.Users.Remove(user);
                Save();
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public User EditUserDetail(int id)
        {
            User data = db.Users.Where(s => s.id == id).FirstOrDefault();
            return data;
        }
        public void UpdateData(User obj)
        {
            User data = db.Users.Where(s => s.id == obj.id).FirstOrDefault();
            data.Name = obj.Name;
            data.email = obj.email;
            data.Zipcode = obj.Zipcode;
            db.SaveChanges();
        }
    }
}
