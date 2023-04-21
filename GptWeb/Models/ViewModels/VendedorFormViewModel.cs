namespace GptWeb.Models.ViewModels
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Setor> Setores { get; set; }
    }
}
