using DivTech.Data;
using DivTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DivTech.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly ApplicationDbContext applicationDbContext;

        public FornecedorController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFornecedorViewModel addFornecedorRequest)
        {

            try 
            {
                var fornecedor = new FornecedorModel()
                {
                    Id = Guid.NewGuid(),
                    Nome = addFornecedorRequest.Nome,
                    CNPJ = addFornecedorRequest.CNPJ,
                    Especialidade = addFornecedorRequest.Especialidade,
                    CEP = addFornecedorRequest.CEP,
                    Endereco = addFornecedorRequest.Endereco,
                };

                await applicationDbContext.Fornecedor.AddAsync(fornecedor);
                await applicationDbContext.SaveChangesAsync();

                return Redirect("/");
            }catch (Exception ex)
            {
                Console.WriteLine("Deu errado");
                return Redirect("/Fornecedor/ErrorForm");
            }

            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var fornecedor = await applicationDbContext.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor == null)
            {
                return Redirect("/");
            }

            var editModel = new FornecedorModel()
            {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome,
                CNPJ = fornecedor.CNPJ,
                Especialidade = fornecedor.Especialidade,
                CEP = fornecedor.CEP,
                Endereco = fornecedor.Endereco,
            };

            //return await Task.Run(() => View("View", editModel));
            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FornecedorModel model)
        {
           
            applicationDbContext.Update(model);
            await applicationDbContext.SaveChangesAsync();  

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var fornecedor = await applicationDbContext.Fornecedor.FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor != null)
            {
                applicationDbContext.Remove(fornecedor);
                await applicationDbContext.SaveChangesAsync();
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult ErrorForm()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
