using KernelFramework.Common.Contracts.EfCore;
using SEMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
        IRepository<Post> Posts { get; }
    }
}
