using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskList.Domain.Entities;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.Domain.ViewModels;
using TaskList.SharedKernel;

namespace TaskList.Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        private readonly IUnitOfWork _unitOfWork;

        public TarefaController(IUnitOfWork unitOfWork, ITarefaService tarefaService)
        {
            _unitOfWork = unitOfWork;
            _tarefaService = tarefaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IAsyncEnumerable<Tarefa> Get()
        {
            return _unitOfWork.TarefaRepository.GetAllAsync();
        }

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status202Accepted)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    return Ok(await _tarefaService.GetByIdAsync(new BaseEntity<Guid>(id)));
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(TarefaModel Tarefa)
        {
            var result = await _tarefaService.AddAsync(Tarefa);
            await _unitOfWork.CommitAsync();
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(TarefaModel Tarefa)
        {
            await _tarefaService.UpdateAsync(Tarefa);
            await _unitOfWork.CommitAsync();
            return Ok(Tarefa);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _tarefaService.RemoveAsync(new BaseEntity<Guid>(id));

            await _unitOfWork.CommitAsync();
            
            return Ok();
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTarefasCount()
        {
            return Ok(await _tarefaService.Count());
        }

    }
}