using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendasService _registroDeVendaService;

        public RegistroDeVendasController(RegistroDeVendasService registroDeVendaService)
        {
            _registroDeVendaService = registroDeVendaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? dataInicial, DateTime? dataFinal)
        {
            if(!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal =  DateTime.Now;
        
            }
            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendaService.FindByDateAsync(dataInicial, dataFinal);
            return View(result);
        }

   
        public async Task<IActionResult> GroupSearch(DateTime? dataInicial, DateTime? dataFinal)
        {
            if (!dataInicial.HasValue)
            {
                dataInicial = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFinal.HasValue)
            {
                dataFinal = DateTime.Now;

            }
            ViewData["dataInicial"] = dataInicial.Value.ToString("yyyy-MM-dd");
            ViewData["dataFinal"] = dataFinal.Value.ToString("yyyy-MM-dd");
            var result = await _registroDeVendaService.FindByDateGroupingasync(dataInicial, dataFinal);
            return View(result);
        }
    }
}
