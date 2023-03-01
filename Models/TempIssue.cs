using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssignmentBackEnd.Models;
public class TempIssue
    {
        public int ProjectId {get;set;}

        public string? Description {get;set;}

        public string? Type {get;set;}
        
        public string? Title {get;set;}
        
        public int ReporterId {get;set;}
        
        public int AssigneeId {get;set;}
        
        public string? Status {get;set;}
    }