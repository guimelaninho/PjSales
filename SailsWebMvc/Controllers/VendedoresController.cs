using System;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using SalesWebMvc.Models.ViewModels;
using System.Runtime.InteropServices.WindowsRuntime;
using SailsWebMvc.Models.ViewModels;
using System.Diagnostics;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorService _vendedorService;
        private readonly DepartmentService _departmentService;

        public VendedoresController(VendedorService vendedorService, DepartmentService departmentService)
        {
            _vendedorService = vendedorService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _vendedorService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departments = departments };
            return View(viewModel);
        }
            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if(!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departments = departments };
                return View(viewModel);
          

            }
             await _vendedorService.insertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new { message = "o Id não foi fornecido"});
            }
            var obj = await _vendedorService.FindByIdAsync(id.Value);

            if (obj ==null)
            {
                return RedirectToAction(nameof(Error), new { message = "Item não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Delete(int id)
        {

            try
            {
                await _vendedorService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityExeception e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message }); 
            }
        }

        public async Task<IActionResult> Details(int? id )
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj =  await _vendedorService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Item não encontrado" });
            }

            return View(obj);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedorService.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Item não encontrado" });
            }
            List<Department> departments = await _departmentService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departments = departments};
                return View(viewModel);

            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Os IDS não correspondem" });
            }

            try
            {
                await _vendedorService.UpdateAsync(vendedor);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
