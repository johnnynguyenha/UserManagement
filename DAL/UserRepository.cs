using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public void UpdatePassword(User _user, string password)
        {
            _user.Password = password;
        }
        public void UpdateUserName(User _user, string username)
        {
            _user.UserName = username;
        }
        public void UpdateFirstName(User _user, string firstName)
        {
            _user.FirstName = firstName;
        }
        public void UpdateLastName(User _user, string lastName)
        {
            _user.LastName = lastName;
        }
        public void UpdatePhoneNumber(User _user, string phoneNumber)
        {
            _user.PhoneNumber = phoneNumber;
        }
        public void UpdateAddress(User _user, string address)
        {
            _user.Address = address;
        }
        public void UpdateRole (User _user, string role)
        {
            _user.Role = role;
        }
        public bool CreateUser(string username, string password, string role)
        {
            var newUser = new User()
            {
                UserName = username,
                Password = password,
                Role = "User"
            };
            _context.Users.Add(newUser);
            return true;
        }
        public bool DeleteUser(User user)
        {
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }
        public string GetUsername(User user)
        {
            return user.UserName;
        }
        public string GetRole(User user)
        {
            return user.Role;
        }
    }
}
