using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LucidiVideoRental.Models;

namespace LucidiVideoRental.Services
{
    public class UserRepository
    {

        private const string CacheKey = "UserStore";

        private User[] users = new User[]
                    {
                new User {id=1,name="Anthony Lucidi",email="alucidi@ltechconsulting.com",phone="631 467 7657",videolist="1,3,4"},
                new User {id=2,name="Bob Smith",email="BSMith@outlook.com",phone="516 268 6744",videolist="0,2,5"},
                new User {id=2,name="Jack Mannon",email="Mannon3@gmail.com",phone="631 894 5587",videolist="2,4"}
                    };

        public User[] GetUsers()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                return (User[])ctx.Cache[CacheKey];
            }

            return new User[]
            {
                new User
                {
                    id=0,
                    name="Placeholder"
                }

            };
        }

        public UserRepository()
        {
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                ctx.Cache[CacheKey] = users;
            }
        }

        public bool SaveUser(User user)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((User[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(user);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
   
}