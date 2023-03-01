using DotnetAssignmentBackEnd.Models;
using Microsoft.EntityFrameworkCore;
namespace DotnetAssignmentBackEnd.Services;
public class LabelService:ILabelService
{
    private ProjectContext _context;

    public LabelService(ProjectContext context) 
    {
        _context = context;   
    }
    public ResponseModel AddLabeltoIssue(int issueId, int labelId)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
            Issue? issue = _context.Issues.Include(i => i.IssueLabels).FirstOrDefault(i => i.IssueId == issueId);
            
            Labels? label = _context.Labels.Find(labelId);

            issue.IssueLabels.Add(label);

            _context.Update(issue);
            
            _context.SaveChanges();

            model.IsSuccess = true;
            
            model.Messsage = "Label added successfully";
        } 
        catch (Exception ex) 
        {
            model.IsSuccess = false;
           
            model.Messsage = "Error: " + ex.Message;
        }
        return model;
    }
    public ResponseModel SaveLabel(Labels label)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
                _context.Add < Labels > (label);
                
                model.Messsage = "Label Inserted Successfully";
                
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
    public ResponseModel DeleteLabelFromIssue(int issueId, int labelId)
    {
        ResponseModel model = new ResponseModel();
        try 
        {
                Issue? issue = _context.Issues.Include(i => i.IssueLabels).FirstOrDefault(i => i.IssueId == issueId);
                
                Labels? label = _context.Find<Labels>(labelId);
                
                issue.IssueLabels.Remove(label);
                
                model.Messsage = "Label Deleted Successfully";
                
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