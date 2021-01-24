using System;
using TaskList.SharedKernel;

namespace TaskList.Domain.Entities
{
    public class Usuario : BaseEntity<Guid>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
