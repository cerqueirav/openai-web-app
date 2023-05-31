using GptApi.Models;
using OpenAI.Files;

namespace GptApi.Services.Interface
{
    public interface IOpenAiService
    {
        Task<IReadOnlyList<FileData>> GetAllFiles();
        Task<IReadOnlyList<string>> CreateImage(ImageViewModel model);
        Task<IReadOnlyList<string>> CreateImageEdit(ImageEditViewModel model);
    }
}
