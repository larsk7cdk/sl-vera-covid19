using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sl_vera_covid19.mvc.Models;
using sl_vera_covid19.mvc.Persistance.Core;
using sl_vera_covid19.mvc.ViewModels;

namespace sl_vera_covid19.mvc.Controllers
{
    public class CovidRegistrationController : Controller
    {
        private readonly ICosmosDbService<CovidRegistrationModel> _cosmosDbService;

        public CovidRegistrationController(ICosmosDbService<CovidRegistrationModel> cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index(string searchString = null)
        {
            var query = "SELECT * FROM c ";
            ViewData["currentFilter"] = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                query += $"WHERE CONTAINS(LOWER(c.name), \"{searchString.ToLower()}\")";
            }

            var model = await _cosmosDbService.GetItemsAsync(query);
            var viewModel = model.Select(MapToViewModel);
            return View(viewModel);
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            var model = await _cosmosDbService.GetItemAsync(id);
            var viewModel = MapToViewModel(model);

            return View(viewModel);
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("Cpr", "Name", "RegistrationDate", "Result")] CovidRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = MapToModel(viewModel);
                model.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(model.Id, model);
                return RedirectToAction("Index");
            }


            return View(viewModel);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null) return BadRequest();

            var model = await _cosmosDbService.GetItemAsync(id);
            if (model == null) return NotFound();

            var viewModel = MapToViewModel(model);

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("Id", "Cpr", "Name", "RegistrationDate", "Result")] CovidRegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = MapToModel(viewModel);
                await _cosmosDbService.UpdateItemAsync(model.Id, model);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }


        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null) return BadRequest();

            var model = await _cosmosDbService.GetItemAsync(id);
            if (model == null) return NotFound();

            var viewModel = MapToViewModel(model);

            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }


        private static CovidRegistrationViewModel MapToViewModel(CovidRegistrationModel model) => new CovidRegistrationViewModel
        {
            Id = model.Id,
            Cpr = model.Cpr,
            Name = model.Name,
            RegistrationDate = model.RegistrationDate,
            Result = model.Result
        };

        private static CovidRegistrationModel MapToModel(CovidRegistrationViewModel viewModel) => new CovidRegistrationModel
        {
            Id = viewModel.Id,
            Cpr = viewModel.Cpr,
            Name = viewModel.Name,
            RegistrationDate = viewModel.RegistrationDate,
            Result = viewModel.Result
        };
    }
}