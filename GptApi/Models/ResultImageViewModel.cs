namespace GptApi.Models
{
    public class ResultImageViewModel
    {
        public List<string> images { get; set; }
        public ResultImageViewModel(List<string> listImages) {
            images = listImages;
        }
    }
}
