using NewZealandWalks.API.Models.Domain;

namespace NewZealandWalks.API.Interfaces
{
    public interface IImageService
    {
        Task<Image> Upload(Image image);
    }
}
