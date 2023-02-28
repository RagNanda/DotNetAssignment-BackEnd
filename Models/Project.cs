using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Project
    {
        [Key]
        public int Id {get;set;}
        public string Description {get;set;}
        public virtual User Creator {get;set;}
        public virtual ICollection<Issue> Issues{get;set;}
        // [JsonIgnore]
    //  public virtual List<Issue> Issues { get; set; }

    }