using GptApi.Models;
using GptApi.Services.Interface;
using OpenAI;
using OpenAI.Files;
using OpenAI.Images;

namespace GptApi.Services.Implementation
{
    public class OpenAiService : IOpenAiService
    {
        private readonly IConfiguration _configuration;
        private readonly OpenAIClient _client; 

        public OpenAiService(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new OpenAIClient(new OpenAIAuthentication(_configuration.GetValue<string>("OpenAiConfig:Key")));
        }

        public async Task<IReadOnlyList<FileData>> GetAllFiles(){
            return await _client.FilesEndpoint.ListFilesAsync();
        }

        public async Task<IReadOnlyList<string>> CreateImage(ImageViewModel model)
        {
            ImageGenerationRequest imageGenerationRequest =
                new ImageGenerationRequest(model.title, model.qty, GetImageSize(model.size), model.save ? _client.OpenAIAuthentication.OrganizationId : null);

            return await _client.ImagesEndPoint.GenerateImageAsync(imageGenerationRequest);
        }

        public async Task<IReadOnlyList<string>> CreateImageEdit(ImageEditViewModel model)
        {
            ImageEditRequest imageEditRequest =
                new ImageEditRequest(model.image, model.title, model.qty, GetImageSize(model.size), model.save ? _client.OpenAIAuthentication.OrganizationId : null);

            return await _client.ImagesEndPoint.CreateImageEditAsync(imageEditRequest);
        }

        #region PRIVATE METHODS
        private ImageSize GetImageSize(int size)
        {
            switch(size)
            {
                case 1: return ImageSize.Small;
                case 2: return ImageSize.Medium;
                case 3: return ImageSize.Large;
                default: return ImageSize.Medium;
            }
        }
        #endregion
    }
}
