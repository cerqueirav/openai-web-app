using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GptWeb.Models
{
    public class ConsultarImagemViewModel
    {
        [Display(Name = "Descrição")]
        public string title { get; set; }

        [Display(Name = "Quantidade")]
        public int qty { get; set; }

        [Display(Name = "Vincular ao Usuario")]
        public bool save { get; set; }
    }
}
