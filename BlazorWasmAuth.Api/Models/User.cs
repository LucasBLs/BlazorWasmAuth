using Microsoft.AspNetCore.Identity;

namespace BlazorWasmAuth.Api.Models;

public class User : IdentityUser<long>
{
    public List<IdentityRole<long>>? Roles { get; set; }
}