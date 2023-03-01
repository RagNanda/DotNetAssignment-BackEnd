using DotnetAssignmentBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using DotnetAssignmentBackEnd.Models;

namespace DotnetAssignmentBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class LabelController:ControllerBase{

    ILabelService _LabelService;

    public LabelController(ILabelService MockService) 
    {
        _LabelService = MockService;
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="Admin,ProjectManager,Standard")]
    public IActionResult AddLabelsToIssue(int issueId,int labelId) 
    {
        try 
        {
            var model = _LabelService.AddLabeltoIssue(issueId,labelId);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPost]
    [Route("[action]")]
    public IActionResult SaveLablels(Labels label)
    {
        try
        {
            var model = _LabelService.SaveLabel(label);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpDelete]
    [Route("[action]")]
    public IActionResult DeleteLabelFromIssue(int issueId, int labelId) 
    {
        try 
        {
            var model = _LabelService.DeleteLabelFromIssue( issueId, labelId);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }
}