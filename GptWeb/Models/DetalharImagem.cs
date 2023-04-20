namespace GptWeb.Models
{
    public class DetalharImagem
    {
        public string descricao { get; set; }
        public List<string> images { get; set; }

        public DetalharImagem() {
            images = new List<string>();
        }
    }
}
