using System;
using SalesWebMvc.Models.Enums;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public RegistroDeVenda()
        {

        }

        public RegistroDeVenda(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }

  
}
