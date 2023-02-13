namespace Simmakers.Test.ArtsiomLyshchyk.Services;

public static class ImageSourceHelper
{
    public static string GetImageSrc(byte[] imageBytes)
    {
        var imageSrc = $"data:image/png;base64,{Convert.ToBase64String(imageBytes)}";
        return imageSrc;
    }
}