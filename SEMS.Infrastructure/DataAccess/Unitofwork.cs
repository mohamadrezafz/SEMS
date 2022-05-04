
using KernelFramework.Common.Contracts.EfCore;
using KernelFramework.DataAccess.EfCore;
using SEMS.Application.Common.Interfaces;
using SEMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Infrastructure.DataAccess
{
    //public interface IUnitofwork : IUnitOfWorkBase<ApplicationDbContext>
    //{
    //    IRepositoryBase<Post, ApplicationDbContext> Posts { get;}
    //}
    //public class Unitofwork : UnitOfWorkBase<ApplicationDbContext> , IUnitofwork
    //{
    //    public Unitofwork(IDbFactory<ApplicationDbContext> dbFactory) : base(dbFactory)
    //    {
    //    }

    //    public IRepositoryBase<Post, ApplicationDbContext> Posts { get;}

    //}

    public class Unitofwork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext ;

        public Unitofwork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
        public Task SaveAsync()
        {
            return _applicationDbContext.SaveChangesAsync();
        }

        public IRepository<Post> Posts { get;}

    }


}
