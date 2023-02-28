using DotnetAssignmentBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotnetAssignmentBackEnd.Models;
using Microsoft.AspNetCore.Authorization;

namespace DotnetAssignmentBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class ProjectController:ControllerBase{

    IProjectService _projectService;

    public ProjectController(IProjectService service) 
    {
        _projectService = service;
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult GetAllProjects() {
        try 
        {
            var projects = _projectService.GetProjectsList();
            if (projects == null) return NotFound();
            return Ok(projects);
        } 
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]/id")]
    public IActionResult GetProjectsById(int id) {
        try 
        {
            var projects = _projectService.GetProjectDetailsById(id);
            if (projects == null) return NotFound();
            return Ok(projects);
        } 
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]/id")]
    public IActionResult GetIssuesByProjectId(int id) 
    {
        try 
        {
            var issues = _projectService.GetIssuesByProjectId(id);
            if (issues.Count == 0) return NotFound();
            return Ok(issues);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin")]
    [HttpPost]
    [Route("[action]")]
    public IActionResult SaveProjects(TempProj projectModel) 
    {
        try 
        {
            var model = _projectService.SaveProject(projectModel);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin")]
    [HttpPut]
    [Route("[action]")]
    public IActionResult UpdateProject(int projectId,string description) 
    {
        try 
        {
            var model = _projectService.UpdateProject(projectId,description);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin")]
    [HttpDelete]
    [Route("[action]")]
    public IActionResult DeleteProject(int id) 
    {
        try 
        {
            var model = _projectService.DeleteProject(id);
            return Ok(model);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
    }
}