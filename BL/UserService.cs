using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DAL;
using Model;

namespace BL
{
    // class that handles the business logic and talks to the data access layer (DAL) for user management.
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // function that resets password for user. return true if successful, false otherwise.
        public bool ResetPassword(string username, string newpassword, string confirmpassword, out string message)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(confirmpassword))
            {
                message = "Empty Field";
                return false;
            }
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null)
            {
                message = "Username does not exist";
                return false;
            }
            if (newpassword != confirmpassword)
            {
                message = "Passwords do not match";
                return false;
            } 
            if (newpassword == user.Password)
            {
                message = "Password is the same as the old password";
                return false;
            } 
            _unitOfWork.Users.UpdatePassword(user, newpassword);
            _unitOfWork.Save();
            message = "Password Changed Succesfully";
            return true;
        }

        // function that logs in user. return true if successful, false otherwise.
        public bool Login(string username, string password, out string message)
        {
            if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(password) == true)
            {
                message = "Empty Field";
                return false;
            }
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null)
            {
                message = "Username does not exist";
                return false; 
            }
            if (user.Password != password)
            {
                message = "Username and Password do not match";
                return false;
            }
            message = "Login Success";
            return true;
        }

        // function that registers a new user. return true if successful, false otherwise.
        public bool Register(string username, string password, string confirmPassword, out string message)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                message = "Field Empty";
                return false;
            }
            var exists = _unitOfWork.Users.GetUserByUsername(username);
            if (exists != null)
            {
                message = "Username Already Exists";
                return false;
            } 
            if (password != confirmPassword)
            {
                message = "Could not Register. Passwords do not match";
                return false;
            }
            _unitOfWork.Users.CreateUser(username, password, "User");
            _unitOfWork.Save();
            message = "Register was Successful";
            return true;
        }

        // function that deletes a user account. return true if successful, false otherwise.
        public bool DeleteAccount(string username)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (_unitOfWork.Users.DeleteUser(user))
            {
                _unitOfWork.Save();
                return true;
            } else
            {
                return false;
            }
            
        }

        // function that gets the username of a user. return the username as a string.
        public string GetUserName(User user)
        {
            if (user == null)
            {
                return null;
            }
            return _unitOfWork.Users.GetUsername(user);
        }

        // function that gets a userlist. returns a list of users.
        public List<User> GetUserList()
        {
            return _unitOfWork.Users.GetUsers();
        }

        // function that gets the role of a user. returns the role as a string.
        public string GetRole(User user)
        {
            return _unitOfWork.Users.GetRole(user);
        }

        // function that changes user details. returns true if successful, false otherwise.
        public bool ChangeDetails(User user, string username, string newusername, string password, string firstName, string lastName, string phoneNumber, string address)
        {
            if (user == null)
            {
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdateUserName(user, newusername);
                _unitOfWork.Users.UpdatePassword(user, password);
                _unitOfWork.Users.UpdateFirstName(user, firstName);
                _unitOfWork.Users.UpdateLastName(user, lastName);
                _unitOfWork.Users.UpdatePhoneNumber(user, phoneNumber);
                _unitOfWork.Users.UpdateAddress(user, address);
                _unitOfWork.Save();
                return true;
            } catch
            {
                return false;
            }
        }

        // function that changes user details without changing password. returns true if successful, false otherwise.
        public bool ChangeDetails(User user, string username, string newusername, string firstName, string lastName, string phoneNumber, string address)
        {
            if (user == null)
            {
                return false;
            }
            try
            {
                _unitOfWork.Users.UpdateUserName(user, newusername);
                _unitOfWork.Users.UpdateFirstName(user, firstName);
                _unitOfWork.Users.UpdateLastName(user, lastName);
                _unitOfWork.Users.UpdatePhoneNumber(user, phoneNumber);
                _unitOfWork.Users.UpdateAddress(user, address);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // function that gets a user by username. returns the user object.
        public User GetUserByUsername(string username)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null)
            {
                throw new ArgumentException("Cannot find User. User not found");
            }
            return user;
        }

        // function that sets password of user by username. 

        public void SetPassword(string username, string password)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password cannot be empty");
            }
            if (user == null)
            {
                throw new ArgumentException("Cannot Set Password. User not found");
            }
            _unitOfWork.Users.UpdatePassword(user, password);
            _unitOfWork.Save();
        }

        // function that gets password of user by username. returns the password as a string.
        public string GetPassword(string username)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user.Password;
        }

        // function that changes password of user. returns true if successful, false otherwise.
        public bool ChangePassword(string username, string oldpassword, string newpassword, string confirmpassword, out string message)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            if (user == null)
            {
                message = "User not found";
                return false;
            }
            if (user.Password != oldpassword)
            {
                message = "Old password is incorrect";
                return false;
            }
            if  (newpassword != confirmpassword)
            {
                message = "New passwords do not match";
                return  false;
            }
            if (oldpassword == newpassword)
            {
                message = "New password cannot be the same as the old password";
                return false;
            }
            _unitOfWork.Users.UpdatePassword(user, newpassword);
            _unitOfWork.Save();
            message = "Password changed successfully";
            return true;
        }
    }
}
