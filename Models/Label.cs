using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Label
    {   public Label(){
            this.Issues=new HashSet<Issue>();
        }
        [Key]
        public int Id {get;set;}
        public string LabelName {get;set;}

        [JsonIgnore]
        public virtual ICollection<Issue>? Issues{get;set;}
    }