using System;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Domain.Entities;
using TaskList.Infrastructure.Data;

namespace TaskList.Infrastructure.Repositories
{
    public class Seeder
    {
        private readonly AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task SeedSimpleUser()
        {
            //Banco de dados migrado para o azure

            //var user = new Usuario
            //{
            //    Id = Guid.NewGuid(),
            //    DataCriacao = DateTime.Now,
            //    Username = "admin",
            //    Password = "123",
            //};

            //if (!_context.Usuarios.Any(r => r.Username == user.Username))
            //{
            //    await _context.Usuarios.AddAsync(user);
            //    await _context.SaveChangesAsync();
            //}
        }
    }
}