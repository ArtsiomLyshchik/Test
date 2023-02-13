using Microsoft.AspNetCore.Identity;

namespace Simmakers.Test.ArtsiomLyshchyk.Models;

public class BaseUser: IdentityUser
{
    public byte[]? ProfileImage { get; set; }
}