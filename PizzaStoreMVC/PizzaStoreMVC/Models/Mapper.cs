using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStoreMVC.Models
{
    public class Mapper
    {
        public static PizzaStoreMVC.Models.Users Map(PizzaDbData.User user)
        {
            return new PizzaStoreMVC.Models.Users()
            {
                Id = user.id,
                Name = user.Name,
                Email = user.email,
                Gender = Convert.ToChar(user.Gender),
                Zipcode = user.Zipcode
            };
        }

    }
}