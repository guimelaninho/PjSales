using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        //declaração de atributos
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, MinimumLength =3, ErrorMessage = "{0} muito curto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com um E-mail válido")]
        public string Email { get; set; }
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        public double SalarioBase { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>();

        //metodos e construtor
       public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, double salarioBase, DateTime dataNascimento, Department department)
        {
            this.Id = id;
            Nome = nome;
            Email = email;
            SalarioBase = salarioBase;
            DataNascimento = dataNascimento;
            Department = department;
        }

        public void AdicionarVenda(RegistroDeVenda registro) //adiciona venda
        {
            Vendas.Add(registro);
        }

        public void RemoverVenda(RegistroDeVenda registro)//exclui venda
        {
            Vendas.Remove(registro);
        }

        public double VendasTotais(DateTime inicial, DateTime final)//pega vendas taotis por intervalo
        {
            return Vendas.Where(reg => reg.Data >= inicial && reg.Data <=final).Sum(reg =>reg.Valor);
        }
    }

}
