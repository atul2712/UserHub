using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserHub.DAL;
using UserHub.DAL.Entities;
using UserHub.Models.User;
using UserHub.Repositories.Interfaces;
using Bcrypt = BCrypt.Net.BCrypt;

namespace UserHub.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        AppDbContext context
        {
            get
            {
                return _dbContext as AppDbContext;
            }
        }
        //Parent class has parameterized constructor so we need to pass dbcontext here.
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public bool CreateUser(User user, string userRole)
        {
            try
            {
                user.Password = Bcrypt.HashPassword(user.Password);
                Role role = context.Roles.Where(r => r.Name == userRole).FirstOrDefault();
                user.Roles.Add(role);
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //Record error log and send email - To Do...
                return false;
            }
        }

        public UserModel ValidateUser(string email, string password)
        {
            User user = context.Users.Include(u => u.Roles).Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                bool isVerified = Bcrypt.Verify(password, user.Password);
                if (isVerified)
                {
                    UserModel model = new UserModel
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Roles = user.Roles.Select(r => r.Name).ToArray()
                    };
                    return model;
                }
            }
            return null;
        }
    }
}
