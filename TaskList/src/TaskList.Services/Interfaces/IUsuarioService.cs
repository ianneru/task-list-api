using System;
using System.Threading.Tasks;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.SharedKernel;

namespace TaskList.Services.Interfaces
{
    public interface IUsuarioService : IBaseService<Usuario,UsuarioModel, BaseEntity<Guid>>
    {
        ValueTask<Usuario> Authenticate(string username, string password);
    }
}