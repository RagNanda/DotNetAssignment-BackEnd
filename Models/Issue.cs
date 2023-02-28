using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Issue
    {   
        // public Issue(){
    //         this.Labels=new HashSet<Label>();
    //     }
        [Key]
         public int Id {get;set;}
        public int ProjectId {get;set;}

        [JsonIgnore]
        public virtual Project Project { get; set; }
        public string? Description {get;set;}

        public string Type{get;set;}

        //  public static IssueType SetType(int type)
        // {
        //     switch (type)
        //     {
        //         case (int)IssueType.Bug:
        //             return "Bug";
        //         case (int)IssueType.Task:
        //             return "Male";
        //         case (int)IssueType.Story:
        //             return "Task";
        //         case (int)IssueType.Epic:
        //             return "Epic";
        //         default:
        //             return "Invalid Data for Type";
        //     }
        // }
        
        public string Title {get;set;}
        //cannot be changed
        public virtual User Reporter {get;set;}
        public virtual User? Assignee {get;set;}

        public virtual ICollection<Label>? Labels{get;set;}
        
        public string Status {get;set;}
}
