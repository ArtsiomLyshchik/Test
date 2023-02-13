using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Simmakers.Test.ArtsiomLyshchyk.Models;
using Exception = System.Exception;

namespace Simmakers.Test.ArtsiomLyshchyk.Services;

public class BaseUserManager: UserManager<BaseUser>
{
    public BaseUserManager(IUserStore<BaseUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<BaseUser> passwordHasher, IEnumerable<IUserValidator<BaseUser>> userValidators, IEnumerable<IPasswordValidator<BaseUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<BaseUser>> logger) 
        : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public async Task<bool> SetUserProfileImageAsync(BaseUser user, byte[] imageBytes, CancellationToken cancellationToken)
    {
        if (user is null)
        {
            throw new ArgumentOutOfRangeException($"{nameof(user)} can not be null");
        }

        var completedSuccessfully = await SetUserProfileImageInternalAsync(user, imageBytes, cancellationToken);
        return completedSuccessfully;
    }

    private async Task<bool> SetUserProfileImageInternalAsync(BaseUser user, byte[] imageBytes, CancellationToken cancellationToken)
    {
        try
        {
            user.ProfileImage = new byte[imageBytes.Length];
            imageBytes.CopyTo(user.ProfileImage, 0);
            
            await Store.UpdateAsync(user,cancellationToken);
            
            return true;
        }
        catch (Exception exception)
        {
            const string errorMessage = "Could not set user profile image";
            Logger.LogError(exception, errorMessage);
            return false;
        }
    }
}