using DotnetAssignmentBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssignmentBackEnd.Services;
public class ProjectService:IProjectService
{
    private ProjectContext _context;
    
    public ProjectService(ProjectContext context) 
    {
        _context = context;
    }

    public ResponseModel DeleteProject(int projectId)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
            Project _temp = GetProjectDetailsById(projectId);
            
            if (_temp != null)
            {
                _context.Remove < Project > (_temp);
                
                _context.SaveChanges();
                
                model.IsSuccess = true;
                
                model.Messsage = "Project Deleted Successfully";
            }
            else 
            {
                model.IsSuccess = false;
               
                model.Messsage = "Project Not Found";
            }
        } 
        catch (Exception ex)
        {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }

    public Project GetProjectDetailsById(int Id)
    {
        Project? project;
        try 
        {
            project = _context.Projects.Include(s=>s.Issues).Include(s=>s.Creator).SingleOrDefault(s=>s.Id==Id);
        } 
        catch (Exception) 
        {
            throw;
        }
        return project;
    }

    public List<Project> GetProjectsList()
    { 
        List < Project > projList;
        try 
        {
            projList = _context.Projects.Include(s=>s.Issues).Include(s=>s.Creator).ToList();
        } 
        catch (Exception) 
        {
            throw;
        }
        return projList;
    }

    public ICollection<Issue> GetIssuesByProjectId(int projectId)
    {
        ICollection<Issue>? issues;
        try
        {
            issues = _context.Projects.Include(s=>s.Issues).Include(s=>s.Creator).SingleOrDefault(s=>s.Id==projectId).Issues;
        } 
        catch (Exception)
        {
            throw;
        }
        return issues;
    }

    public ResponseModel SaveProject(TempProj projectModel)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
                User? creator = _context.Find<User>(projectModel.CreatorId);
        
                Project _temp=new Project(){
        
                    Description=projectModel.Description,
        
                    Creator=creator
                };
                _context.Add < Project > (_temp);
                
                model.Messsage = "Project Inserted Successfully";
                
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
    public ResponseModel UpdateProject(int projectId, string description)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
            Project? proj = _context.Find<Project>(projectId);
            
            proj.Description = description;
            
            model.Messsage = "Project Updated Successfully";
            
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
}