using DotnetAssignmentBackEnd.Models;
namespace DotnetAssignmentBackEnd.Services;
public interface ILabelService
    {
       
        ResponseModel SaveLabel(Label labelModel);

        ResponseModel AddLabeltoIssue(int issueId,int labelId);

        ResponseModel DeleteLabelFromIssue(int issueId,int labelId);

    }