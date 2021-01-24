using System;
using TaskList.SharedKernel;

namespace TaskList.Domain.ViewModels
{
    public class UsuarioModel : BaseModel<Guid>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
