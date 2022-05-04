using KernelFramework.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application.Common.Interfaces
{
    public interface IRequestWrapper<T> : IRequest<GeneralBaseResponse<T>>
    {

    }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, GeneralBaseResponse<TOut>> where TIn : IRequestWrapper<TOut>
    {

    }

    
}
