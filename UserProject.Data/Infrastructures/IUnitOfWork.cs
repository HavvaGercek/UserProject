using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserProject.Data.Interfaces;

namespace UserProject.Data.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        void Commit();
    }
}
