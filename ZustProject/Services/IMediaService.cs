namespace ZustProject.Services
{
    public interface IMediaService
    {
        Task<string> UploadMediaAsync(IFormFile file);
    }
}
