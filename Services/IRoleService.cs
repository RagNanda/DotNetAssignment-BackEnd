using DotnetAssignmentBackEnd.Models;

namespace DotnetAssignmentBackEnd.Services;
public interface IRoleService{
    ResponseModel AddRole(RoleDTO model);
    ResponseModel AssignRole(int UserId,int RoleId);
}