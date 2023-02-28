using DotnetAssignmentBackEnd.Models;
namespace DotnetAssignmentBackEnd.Services;
public interface IIssueService
    {
       
        List<Issue> GetIssuesList();
        Issue GetIssueDetailsById(int empId);
        ResponseModel SaveIssue(TempIssue issueModel);
        ResponseModel UpdateIssue(int issueId,IssueUpdate issue);
        ResponseModel UpdateStatus(int issueId,string status);
        ResponseModel DeleteIssue(int issueId);
        ResponseModel AssignIssue(int issueId,int userId);
    }