using AutoMapper;
using System;
using System.Threading.Tasks;
using TaskList.Domain.Entities;
using TaskList.Domain.ViewModels;
using TaskList.Infrastructure.Repositories.Interfaces;
using TaskList.Services.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Services.Services
{
    public class UsuarioService : BaseService<Usuario,UsuarioModel, BaseEntity<Guid>>, IUsuarioService
    {
        public UsuarioService(IMapper mapper,IUnitOfWork unitOfWork,
            IServiceValidator<Usuario> validator) : base(
            mapper,
            unitOfWork.UsuarioRepository,
            validator)
        {
        }

        public async ValueTask<Usuario> Authenticate(string username, string password)
        {
            var user = await Repository.Get(w =>w.Username == username && w.Password == password);

            if (user == default)
                return default;

            user.Password = string.Empty;

            return user;
        }
    }
}