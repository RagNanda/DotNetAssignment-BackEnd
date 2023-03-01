
using DotnetAssignmentBackEnd.Models;

namespace DotnetAssignmentBackEnd.Services;
public interface IUserService
{
    User GetUserById(int UserId);

    ResponseModel SaveUser(UserDTO User);
    
    ResponseModel DeleteUser(int UserId);

}