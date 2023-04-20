namespace GptWeb.Models.JsonDeserialized
{
    public class ImagemJson
    {
        public Value value { get; set; }
        public int statusCode { get; set; }
        public object contentType { get; set; }
    }
    
    public class Value
    {
        public string imagens { get; set; }
    }
}
