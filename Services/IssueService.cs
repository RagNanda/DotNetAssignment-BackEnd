using DotnetAssignment;
using DotnetAssignmentBackEnd.Models;
using Microsoft.EntityFrameworkCore;
namespace DotnetAssignmentBackEnd.Services;
public class IssueService:IIssueService
{
    private ProjectContext _context;

    public IssueService(ProjectContext context) {
        _context = context;   
    }

    public ResponseModel DeleteIssue(int issueId)
    {
        ResponseModel model = new ResponseModel();
        try {
            Issue _temp = GetIssueDetailsById(issueId);
            if (_temp != null) {
                _context.Remove < Issue > (_temp);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Issue Deleted Successfully";
            } else {
                model.IsSuccess = false;
                model.Messsage = "Issue Not Found";
            }
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    public Issue GetIssueDetailsById(int issueId)
    {
        Issue? issue;
        try {
            issue = _context.Issues.Include(s=>s.Project).Include(s=>s.IssueReporter).Include(s=>s.IssueAssignee).Include(s=>s.IssueLabels).SingleOrDefault(s=>s.IssueId==issueId);
        } catch (Exception) {
            throw;
        }
        return issue;
    }
    public List<Issue> GetIssuesList()
    { 
         List < Issue > issueList;
        try {
            issueList = _context.Issues.Include(s=>s.Project).Include(s=>s.IssueReporter).Include(s=>s.IssueAssignee).Include(s=>s.IssueLabels).ToList();
        } catch (Exception) {
            throw;
        }
        return issueList;
    }

    public ResponseModel SaveIssue(TempIssue issueModel)
    {
        ResponseModel model = new ResponseModel();
        try {   bool exists;
                exists = Enum.IsDefined(typeof(IssueType), issueModel.Type);
                if(exists)
                {
                    Project? project = _context.Find<Project>(issueModel.ProjectId);
                    
                    User? reporter = _context.Find<User>(issueModel.ReporterId);
                    
                    Issue issue=new Issue(){
                    
                        ProjectId=issueModel.ProjectId,
                    
                        IssueDescription=issueModel.Description,
                    
                        IssueType=issueModel.Type,
                    
                        IssueStatus=issueModel.Status,
                    
                        IssueTitle=issueModel.Title,
                    
                        IssueReporter=reporter,
                    
                        Project= project
                    };
                    
                    _context.Add < Issue > (issue);
                   
                    model.Messsage = "Issue Inserted Successfully";
                   
                    _context.SaveChanges();
                   
                    model.IsSuccess = true;
                }
                else
                {
                    model.IsSuccess = false;
                 
                    model.Messsage = "Invalid Type of issue" ;
                }
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
         
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }
        public ResponseModel UpdateIssue(int issueId, IssueDTO tempIssue)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
                bool existsType;
         
                bool existsStatus;
         
                existsType = Enum.IsDefined(typeof(IssueType), tempIssue.Type);
         
                existsStatus= Enum.IsDefined(typeof(Status), tempIssue.Status);
         
                if(existsType && existsStatus){
         
                    Issue? issue = _context.Find<Issue>(issueId);
            
                    issue.IssueType = tempIssue.Type;
            
                    issue.IssueDescription = tempIssue.Description;
            
                    issue.IssueTitle = tempIssue.Title;
            
                    model.Messsage = "Issue Inserted Successfully";
            
                    _context.SaveChanges();
            
                    model.IsSuccess = true;
                }
            else
            {
                model.IsSuccess = false;
            
                model.Messsage = "Invalid Type or Status" ;
            }
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
           
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

     public ResponseModel AssignIssue(int issueId, int userId)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
            Issue? issue = _context.Find<Issue>(issueId);
        
            User? user = _context.Find<User>(userId);
        
            issue.IssueAssignee = user;
        
            model.Messsage = "Issue Assigned Successfully";
        
            _context.SaveChanges();

            model.IsSuccess = true;
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
            
            model.Messsage = "Error : " + ex.Message;
        }
        return model;        
    }
    
      public ResponseModel UpdateStatus(int issueId, string status)
    {
        ResponseModel model = new ResponseModel();
        try {
                Issue? issue = _context.Find<Issue>(issueId);
                
                issue.IssueStatus = status;
                
                model.Messsage = "Status Updated Successfully";
                
                _context.SaveChanges();
                
                model.IsSuccess = true;
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
            
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }
    public Issue SearchIssue(string Title, string Description){    
         Issue issue = _context.Issues.    
         FirstOrDefault(s=> s.IssueTitle == Title && s.IssueDescription == Description);    
         return issue;    
    }    
}
