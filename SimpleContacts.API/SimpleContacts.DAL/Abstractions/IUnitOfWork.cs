using System;
using System.Threading.Tasks;

namespace SimpleContacts.DAL.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
