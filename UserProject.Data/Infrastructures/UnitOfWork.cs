using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserProject.Data.Interfaces;
using UserProject.Data.Repositories;

namespace UserProject.Data.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserContext _context;
        private IUserRepository _userRepository;
        public UnitOfWork(UserContext context, IUserRepository users)
        {
           this. _context = context;
        }
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public void Commit()
        {
           _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
