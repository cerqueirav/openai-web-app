using System.Collections.Generic;
using System;
using System.Linq;

namespace GptWeb.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();

        public Setor()
        {
        }

        public Setor(int id, string Nome)
        {
            Id = id;
            Nome = Nome;
        }

        public void AddVendedor(Vendedor Vendedor)
        {
            Vendedors.Add(Vendedor);
        }
        public double TotalSales(DateTime initial, DateTime final)
        {
            return Vendedors.Sum(Vendedor => Vendedor.TotalSales(initial, final));
        }
    }
}
