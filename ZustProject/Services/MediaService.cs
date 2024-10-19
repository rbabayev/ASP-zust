
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ZustProject.Settings;

namespace ZustProject.Services
{
    public class MediaService : IMediaService
    {
        private IConfiguration _configuration;
        private readonly CloudinarySettings? _cloudinarySettings;
        private readonly Cloudinary _cloudinary;
        public MediaService(IConfiguration configuration)
        {
            _configuration = configuration;
            _cloudinarySettings = _configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new(

                _cloudinarySettings.CloudName,

                _cloudinarySettings.ApiKey,

                _cloudinarySettings.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<string> UploadMediaAsync(IFormFile file)
        {
            ImageUploadResult uploadedResult = new ImageUploadResult();

            if (file?.Length > 0)
            {
                using (Stream? stream = file.OpenReadStream())
                {
                    ImageUploadParams uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };
                    uploadedResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadedResult != null)
                    {
                        return uploadedResult.Url.ToString();
                    }
                }
            }
            return "";
        }
    }
}
