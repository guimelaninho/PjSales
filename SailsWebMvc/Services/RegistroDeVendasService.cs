
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class RegistroDeVendasService
    {
        private readonly SalesWebMvcContext _context;
        public RegistroDeVendasService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVenda>> FindByDateAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var result = from obj in _context.RegistroDeVenda select obj;

            if (dataInicial.HasValue)
            {
                result =result.Where(x => x.Data >= dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                result = result.Where(x => x.Data <= dataFinal.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x =>x.Data )
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,RegistroDeVenda>>> FindByDateGroupingasync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var result = from obj in _context.RegistroDeVenda select obj;

            if (dataInicial.HasValue)
            {
                result = result.Where(x => x.Data >= dataInicial.Value);
            }

            if (dataFinal.HasValue)
            {
                result = result.Where(x => x.Data <= dataFinal.Value);
            }

            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Department)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Department)
                .ToListAsync();
        }
    }
}
