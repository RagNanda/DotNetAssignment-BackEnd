using Microsoft.EntityFrameworkCore;
// using PYM.models;
using DotnetAssignmentBackEnd.Models;

namespace DotnetAssignmentBackEnd.Services;
public class UserService : IUserService
{
    private ProjectContext _context;
    public UserService(ProjectContext context){
        _context=context;
    }
    public ResponseModel DeleteUser(int UserId)
    {
        ResponseModel model = new ResponseModel();
        try {
            User _temp = GetUserById(UserId);
            if (_temp != null) {
                _context.Remove < User > (_temp);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "User Deleted Successfully";
            } else {
                model.IsSuccess = false;
                model.Messsage = "User Not Found";
            }
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    // public List<User> GetAllUsers()
    // {
    //     List < User > Users;
    //     try {
    //         Users = _context.User.Include(s=>s.Issue).ToList();
    //     } catch (Exception) {
    //         throw;
    //     }
    //     return Users;
    // }

    public User GetUserById(int UserId)
    {
        User User;
        try {
            User = _context.Find < User > (UserId);
        } catch (Exception) {
            throw;
        }
        return User;
    }

    public ResponseModel SaveUser(UserDTO User)
    {
        ResponseModel model = new ResponseModel();
        try {
                User user = new User(){
                    Name = User.Name,
                    UserName = User.UserName,
                    Password = User.Password
                };
                _context.Add < User > (user);
                model.Messsage = "User Inserted Successfully";
            _context.SaveChanges();
            model.IsSuccess = true;
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }
}
