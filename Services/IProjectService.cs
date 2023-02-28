using DotnetAssignmentBackEnd.Models;
namespace DotnetAssignmentBackEnd.Services;
public interface IProjectService
    {
        List<Project> GetProjectsList();
        Project GetProjectDetailsById(int empId);
        ICollection<Issue> GetIssuesByProjectId(int projectId);
        ResponseModel SaveProject(TempProj projectModel);
        ResponseModel UpdateProject(int projectId,string description);
        ResponseModel DeleteProject(int projectId);
    }