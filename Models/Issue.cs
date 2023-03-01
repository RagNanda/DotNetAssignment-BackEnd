using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Issue
    {

        [Key]
         public int IssueId {get;set;}

        public string? IssueDescription {get;set;}

        public string? IssueType{get;set;}
        
        public string? IssueTitle {get;set;}

        public virtual User? IssueReporter {get;set;}

        public virtual User? IssueAssignee {get;set;}

        public virtual ICollection<Labels>? IssueLabels{get;set;}
        
        public string? IssueStatus {get;set;}

        //Navigation properties
        
        public int ProjectId {get;set;}

        [JsonIgnore]
        public virtual Project? Project { get; set; }
}
