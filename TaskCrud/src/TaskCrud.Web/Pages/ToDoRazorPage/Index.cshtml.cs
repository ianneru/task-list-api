using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Core.Entities;
using TaskList.SharedKernel.Interfaces;

namespace TaskList.Web.Pages.ToDoRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repository;

        public List<ToDoItem> ToDoItems { get; set; }

        public IndexModel(IRepository repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            ToDoItems = await _repository.ListAsync<ToDoItem>();
        }
    }
}
