using System;

namespace API.Entities;

public class UserLike
{
    public AppUser SourceUser { get; set; } = null!;  //doing like it
    public int SourceUserId { get; set; }
    public AppUser TargetUser { get; set; } = null!; // receing like it
    public int TargetUserId { get; set; }

}
