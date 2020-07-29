using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Department
    {
        //declaração de atributos
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        //construtor e métodos
        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AdicionarVendedor(Vendedor vendedor)// adiciona um vendedor em um depertamaento
        {
            Vendedores.Add(vendedor);
        }

        public double TotalDeVendas( DateTime inicial, DateTime final)//soma o total de vendas por vendedor
        {
            return Vendedores.Sum(vendedor => vendedor.VendasTotais(inicial, final));
        }
    }
}
