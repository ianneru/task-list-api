using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using TaskList.Core.Entities;
using TaskList.SharedKernel.Interfaces;

namespace TaskList.Web.Endpoints.ToDoItems
{
    public class Update : BaseAsyncEndpoint<UpdateToDoItemRequest, ToDoItemResponse>
    {
        private readonly IRepository _repository;

        public Update(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPut("/ToDoItems")]
        [SwaggerOperation(
            Summary = "Updates a ToDoItem",
            Description = "Updates a ToDoItem with a longer description",
            OperationId = "ToDoItem.Update",
            Tags = new[] { "ToDoItemEndpoints" })
        ]
        public override async Task<ActionResult<ToDoItemResponse>> HandleAsync(UpdateToDoItemRequest request)
        {
            var existingItem = await _repository.GetByIdAsync<ToDoItem>(request.Id);

            existingItem.Title = request.Title;
            existingItem.Description = request.Description;

            await _repository.UpdateAsync(existingItem);

            var response = new ToDoItemResponse
            {
                Id = existingItem.Id,
                Title = existingItem.Title,
                Description = existingItem.Description,
                IsDone = existingItem.IsDone
            };
            return Ok(response);
        }
    }
}
