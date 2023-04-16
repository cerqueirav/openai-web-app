namespace GptApi.Models
{
    public class ResultImageViewModel
    {
        public List<String> imagens { get; set; }

        public ResultImageViewModel() { 
            imagens = new List<String>();
        }
    }
}
