using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models.Enums;
using System.Runtime.InteropServices.ComTypes;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Vendedor.Any() || _context.RegistroDeVenda.Any())
            {
                return; //caso o banco já possua registros
            }
            Department d1 = new Department(1, "Computador");
            Department d2 = new Department(2, "Eletrônicos");
            Department d3 = new Department(3, "Moda");
            Department d4 = new Department(4, "Livros");

            Vendedor v1 = new Vendedor(1, "João da Silva", "Joao@gmail.com", 1000.0, new  DateTime(1998, 4, 21),  d1);
            Vendedor v2 = new Vendedor(2, "Carolina da silva", "Carolina@gmail.com", 3500.0, new DateTime(1979, 12, 31), d2);
            Vendedor v3 = new Vendedor(3, "Rafael Costa", "Rafael@gmail.com", 2200.0, new DateTime(1988, 1, 15), d1);
            Vendedor v4 = new Vendedor(4, "Camila Guimarães", "camila@gmail.com", 3000.0, new DateTime(1993, 11, 30), d4);
            Vendedor v5 = new Vendedor(5, "Jean Silva", "Jean@gmail.com", 4000.0, new DateTime(2000, 1, 9), d3);
            Vendedor v6 = new Vendedor(6, "Jessica souza", "Jessica@gmail.com", 3000.0, new DateTime(1997, 3, 4), d3);

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2018, 09, 25), 11000.0, StatusVenda.Faturado, v1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2018, 09, 4), 7000.0, StatusVenda.Faturado, v5);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2018, 09, 13), 4000.0, StatusVenda.Cancelado, v4);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2018, 09, 1), 8000.0, StatusVenda.Faturado, v1);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2018, 09, 21), 3000.0, StatusVenda.Faturado, v3);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2018, 09, 15), 2000.0, StatusVenda.Faturado, v1);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Faturado, v2);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2018, 09, 11), 4000.0, StatusVenda.Faturado, v4);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, v6);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2018, 09, 7), 9000.0, StatusVenda.Faturado, v6);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2018, 09, 13), 6000.0, StatusVenda.Faturado, v2);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, v3);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Faturado, v4);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2018, 09, 4), 3000.0, StatusVenda.Faturado, v5);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2018, 09, 12), 4000.0, StatusVenda.Faturado, v1);
            RegistroDeVenda r16 = new RegistroDeVenda(16, new DateTime(2018, 10, 5), 2000.0, StatusVenda.Faturado, v4);
            RegistroDeVenda r17 = new RegistroDeVenda(17, new DateTime(2018, 10, 1), 12000.0, StatusVenda.Faturado, v1);
            RegistroDeVenda r18 = new RegistroDeVenda(18, new DateTime(2018, 10, 24), 6000.0, StatusVenda.Faturado, v3);
            RegistroDeVenda r19 = new RegistroDeVenda(19, new DateTime(2018, 10, 22), 8000.0, StatusVenda.Faturado, v5);
            RegistroDeVenda r20 = new RegistroDeVenda(20, new DateTime(2018, 10, 15), 8000.0, StatusVenda.Faturado, v6);
            RegistroDeVenda r21 = new RegistroDeVenda(21, new DateTime(2018, 10, 17), 9000.0, StatusVenda.Faturado, v2);
            RegistroDeVenda r22 = new RegistroDeVenda(22, new DateTime(2018, 10, 24), 4000.0, StatusVenda.Faturado, v4);
            RegistroDeVenda r23 = new RegistroDeVenda(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, v2);
            RegistroDeVenda r24 = new RegistroDeVenda(24, new DateTime(2018, 10, 12), 8000.0, StatusVenda.Faturado, v5);
            RegistroDeVenda r25 = new RegistroDeVenda(25, new DateTime(2018, 10, 31), 7000.0, StatusVenda.Faturado, v3);
            RegistroDeVenda r26 = new RegistroDeVenda(26, new DateTime(2018, 10, 6), 5000.0, StatusVenda.Faturado, v4);
            RegistroDeVenda r27 = new RegistroDeVenda(27, new DateTime(2018, 10, 13), 9000.0, StatusVenda.Pendente, v1);
            RegistroDeVenda r28 = new RegistroDeVenda(28, new DateTime(2018, 10, 7), 4000.0, StatusVenda.Faturado, v3);
            RegistroDeVenda r29 = new RegistroDeVenda(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Faturado, v5);
            RegistroDeVenda r30 = new RegistroDeVenda(30, new DateTime(2018, 10, 12), 5000.0, StatusVenda.Faturado, v2);


            _context.Department.AddRange(d1, d3, d4, d4);
            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);
            _context.RegistroDeVenda.AddRange(
               r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
               r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
               r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
           );

            _context.SaveChanges();

        }
    }
}
