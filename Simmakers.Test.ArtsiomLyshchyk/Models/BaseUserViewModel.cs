namespace Simmakers.Test.ArtsiomLyshchyk.Models;

public class BaseUserViewModel
{
    public string Id { get; set; }
    
    public string UserName { get; set; }
    
    public byte[] ProfileImage { get; set; }

    public static BaseUserViewModel From(BaseUser user)
    {
        if (user is null)
        {
            throw new ArgumentOutOfRangeException(nameof(user), "Can not be null");
        }

        return new()
        {
            Id = user.Id,
            UserName = user.UserName,
            ProfileImage = user.ProfileImage
        };
    }
}