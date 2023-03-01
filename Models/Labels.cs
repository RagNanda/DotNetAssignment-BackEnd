using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Labels
    {   
        public Labels()
        {
            this.Issues=new HashSet<Issue>();
        }
        
        [Key]
        public int LabelId {get;set;}
        
        public string? LabelValue {get;set;}

        [JsonIgnore]
        public virtual ICollection<Issue>? Issues {get;set;}
    
    }