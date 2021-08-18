using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.Model.Repository;

namespace Test.Model.DataManager
{
    public class UserManager : IDataRepository<User>
    {
        readonly bilbixContext _userContext;

        public UserManager(bilbixContext userContext)
        {
            _userContext = userContext;
        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public User Get(long id)
        {
            return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public void Add(User user)
        {
            _userContext.Add(user);
            _userContext.SaveChanges();
        }

        public void Update(User userToUpdate, User user)
        {
            userToUpdate.Email = user.Email;
            userToUpdate.Orders = user.Orders;
            userToUpdate.Password = user.Password;
            userToUpdate.UserGroup = user.UserGroup;
            userToUpdate.Username = user.Username;

            _userContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _userContext.Remove(user);
            _userContext.SaveChanges();
        }
        
    }
}
