
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
    ILabelService _labelService;
    public LabelController(ILabelService service) {
        _labelService = service;
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="Admin,ProjectManager,Standard")]
    public IActionResult AddLabelsToIssue(int issueId,int labelId) {
        try {
            var model = _labelService.AddLabeltoIssue(issueId,labelId);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPost]
    [Route("[action]")]
    public IActionResult SaveLablels(Label label) {
        try {
            var model = _labelService.SaveLabel(label);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpDelete]
    [Route("[action]")]
    public IActionResult DeleteLabelFromIssue(int issueId, int labelId) {
        try {
            var model = _labelService.DeleteLabelFromIssue( issueId, labelId);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }
}