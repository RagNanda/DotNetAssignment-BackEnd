using DotnetAssignmentBackEnd.Models;
namespace DotnetAssignmentBackEnd.Services;
public interface IIssueService
    {
       
        List<Issue> GetIssuesList();

        Issue GetIssueDetailsById(int empId);
        
        ResponseModel SaveIssue(TempIssue issueModel);
        
        ResponseModel UpdateIssue(int issueId,IssueDTO issue);
        
        ResponseModel UpdateStatus(int issueId,string status);
        
        ResponseModel DeleteIssue(int issueId);
        
        ResponseModel AssignIssue(int issueId,int userId);

        Issue SearchIssue(string Title,string Description);
    }