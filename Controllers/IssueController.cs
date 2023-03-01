using DotnetAssignmentBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using DotnetAssignmentBackEnd.Models;
using DotnetAssignmentBackEnd;

namespace DotnetAssignmentBackEnd.Controllers;

[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
[ApiController]
[Route("[controller]")]
public class IssueController:ControllerBase
{

    IIssueService _IssueService;

    private ProjectContext _DbContext;

    public IssueController(IIssueService MockService,ProjectContext context) 
    {
        _DbContext = context;

        _IssueService = MockService;
        
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager,standard")]
    public IActionResult GetIssues() 
    {
        try 
        {
            var issues = _IssueService.GetIssuesList();
            
            Console.WriteLine(issues);
            
            if (issues == null) return NotFound();
            return Ok(issues);
        } 

        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager")]
    public IActionResult SaveIssues(TempIssue issueModel) 
    {
        try 
        {
            var model = _IssueService.SaveIssue(issueModel);
            return Ok(model);
        } 
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager")]
    public IActionResult DeleteIssue(int id) 
    {
        try 
        {
            var model = _IssueService.DeleteIssue(id);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }
    
    [HttpGet]
    [Route("[action]/id")]
    [Authorize(Roles="admin,projectManager,standard")]
    public IActionResult GetIssuesById(int id) {
        try 
        {
            var issues = _IssueService.GetIssueDetailsById(id);
            if (issues == null) return NotFound();
            return Ok(issues);
        } 
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager")]
    public IActionResult AssignIssue(int issueId,int userId) {
        try 
        {
            var model = _IssueService.AssignIssue(issueId,userId);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager")]
    public IActionResult UpdateIssue(int issueId,IssueDTO issueModel) 
    {
        try 
        {
            var model = _IssueService.UpdateIssue(issueId,issueModel);
            return Ok(model);
        } 
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager")]
    public ResponseModel UpdateStatus(int issueId, string status)
    {    
        ResponseModel model = new ResponseModel();
        try 
        {
            Issue? issue = _DbContext.Find<Issue>(issueId);
            int MockStatus = 0, Temp = 0;
            foreach (string i in Enum.GetNames(typeof(Status)))
            {
                if (i==status) 
                {
                        break;
                }
                MockStatus = MockStatus+1;
            }
            foreach (string i in Enum.GetNames(typeof(Status)))
            {
                if (i==issue.IssueStatus)
                {
                    break;
                }
                 Temp=Temp+1;
            }
            if(MockStatus<=Temp+1)
            {
                issue.IssueStatus = status;
                model.Messsage = "Status Updated Successfully";
                _DbContext.SaveChanges();
                model.IsSuccess = true;
            }
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,projectManager,standard")]
    public IActionResult GetIssueBySearch(string Title,string Description) 
    {
        try 
        {
            var issues = _IssueService.SearchIssue(Title,Description);
            
            //Console.WriteLine(issues);
            
            if (issues == null) return NotFound();
            return Ok(issues);
        } 

        catch (Exception e) 
        {
            return BadRequest();
        }
    }

}