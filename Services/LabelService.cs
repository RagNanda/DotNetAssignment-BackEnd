using DotnetAssignmentBackEnd.Models;
using Microsoft.EntityFrameworkCore;
// using DotnetAssignment.Services.ProjectService;
namespace DotnetAssignmentBackEnd.Services;
// namespace DotnetAssignment.Services.ProjectService;
public class LabelService:ILabelService
{
    private ProjectContext _context;
    // public ProjectService projService;

    public LabelService(ProjectContext context) {
        _context = context;   
    }
    public ResponseModel AddLabeltoIssue(int issueId, int labelId)
    {
        ResponseModel model = new ResponseModel();
        try {
        // Retrieve the Issue and Label objects from the database
            Issue issue = _context.Issues.Include(i => i.Labels).FirstOrDefault(i => i.Id == issueId);
            Label label = _context.Labels.Find(labelId);

        // Add the Label object to the Labels navigation property of the Issue object
            issue.Labels.Add(label);

        // Update the Issue object in the database and save changes
            _context.Update(issue);
            _context.SaveChanges();

        model.IsSuccess = true;
        model.Messsage = "Label added successfully";
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error: " + ex.Message;
        }
    return model;
    }
    public ResponseModel SaveLabel(Label label)
    {
        ResponseModel model = new ResponseModel();
        try {
                _context.Add < Label > (label);
                model.Messsage = "Label Inserted Successfully";
                _context.SaveChanges();
                model.IsSuccess = true;
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
    }
    public ResponseModel DeleteLabelFromIssue(int issueId, int labelId)
    {
        ResponseModel model = new ResponseModel();
        try {
                Issue issue = _context.Issues.Include(i => i.Labels).FirstOrDefault(i => i.Id == issueId);
                Label label = _context.Find<Label>(labelId);
                issue.Labels.Remove(label);
                model.Messsage = "Label Deleted Successfully";
            _context.SaveChanges();
            model.IsSuccess = true;
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;        
    }
}