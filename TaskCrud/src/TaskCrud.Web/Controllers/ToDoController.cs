using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Core;
using TaskList.Core.Entities;
using TaskList.SharedKernel.Interfaces;
using TaskList.Web.ApiModels;

namespace TaskList.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _repository.ListAsync<ToDoItem>())
                            .Select(ToDoItemDTO.FromToDoItem);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}
