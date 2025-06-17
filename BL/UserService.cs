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
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool ResetPassword(string username, string newpassword, string confirmpassword, out string message)
        {
            string usernameLower = username.ToLower();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(newpassword) || string.IsNullOrEmpty(confirmpassword))
            {
                message = "Empty Field";
                return false;
            }
            var exists = _unitOfWork.Users.GetUserByUsername(username);
            if (exists == null)
            {
                message = "Username does not exist";
                return false;
            } else if (newpassword != confirmpassword)
            {
                message = "Passwords do not match";
                return false;
            } else if (newpassword == exists.Password)
            {
                message = "Password is the same as the old password";
                return false;
            } else 
            {
                _unitOfWork.Users.UpdatePassword(exists, newpassword);
                _unitOfWork.Save();
                message = "Password Changed Succesfully";
                return true;
            }
        }

        public bool Login(string username, string password, out string message)
        {
            string usernameLower = username.ToLower();
            if (string.IsNullOrEmpty(username) == true || string.IsNullOrEmpty(password) == true)
            {
                message = "Empty Field";
                return false;
            }
            var exists = _unitOfWork.Users.GetUserByUsername(username);
            if (exists == null)
            {
                message = "Username does not exist";
                return false; 
            } else if (exists.Password != password)
            {
                message = "Username and Password do not match";
                return false;
            } else
            {
                message = "Login Success";
                return true;
            }
}
        public bool Register(string username, string password, string confirmPassword, out string message)
        {
            message = "";
            string usernamelower = username.ToLower();
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
            else if (password != confirmPassword)
            {
                message = "Passwords do not match";
                return false;
            } else
            {
                _unitOfWork.Users.CreateUser(username, password, "User");
                _unitOfWork.Save();
                message = "Register was Successful";
                return true;
            }
        }
        public bool DeleteAccount(string username)
        {
            var exists = _unitOfWork.Users.GetUserByUsername(username);
            var deleteWorked = _unitOfWork.Users.DeleteUser(exists);
            if (deleteWorked)
            {
                _unitOfWork.Save();
                return true;
            } else
            {
                return false;
            }
            
        }

        public string GetUserName(User user)
        {
            return _unitOfWork.Users.GetUsername(user);
        }
        public List<User> GetUserList()
        {
            return _unitOfWork.Users.GetUsers();
        }

        public string GetRole(string username)
        {
            return _unitOfWork.Users.GetRole(username);
        }

        public void ChangeDetails(string username, string password, string firstName, string lastName, string phoneNumber, string address)
        {
            var user = _unitOfWork.Users.GetUserByUsername(username);
            _unitOfWork.Users.UpdateUserName(user, username);
            _unitOfWork.Users.UpdatePassword(user, password);
            _unitOfWork.Users.UpdateFirstName(user, firstName);
            _unitOfWork.Users.UpdateLastName(user, lastName);
            _unitOfWork.Users.UpdatePhoneNumber(user, phoneNumber);
            _unitOfWork.Users.UpdateAddress(user, address);
            _unitOfWork.Save();
        }

        public User GetUserByUsername(string username)
        {
            return _unitOfWork.Users.GetUserByUsername(username);
        }

    }
}
