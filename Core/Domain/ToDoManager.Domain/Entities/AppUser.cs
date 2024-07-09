using Microsoft.AspNetCore.Identity;

namespace ToDoManager.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public  ICollection<Log> Logs { get; set; }
}