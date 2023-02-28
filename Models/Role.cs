using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DotnetAssignmentBackEnd.Models;
public class Role{
    public Role(){
        this.Users = new HashSet<User>();
    }
    [Key]
    public int Id{get;set;}
    public string RoleName{get;set;}
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; }
}