using AutoMapper;
using KernelFramework.Common;
using SEMS.Application.Common.Interfaces;
using SEMS.Core.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application.Handlers.Post.Command
{
    public class Create
    {
        public class CreateResponse
        {
            public long Id { get; set; }
        }

        public class CreateRequest : IRequestWrapper<CreateResponse>
        {
            public string Caption { get; set; }
        }

        public class CreateHandler : IRequestHandlerWrapper<CreateRequest, CreateResponse>
        {

            private readonly IUnitOfWork _unitofwork;
            private readonly IMapper _mapper;
            public CreateHandler(IUnitOfWork unitofwork, IMapper mapper)
            {
                _unitofwork = unitofwork;
                _mapper = mapper;
            }

            public async Task<GeneralBaseResponse<CreateResponse>> Handle(CreateRequest request, CancellationToken cancellationToken)
            {
                var resposne = new GeneralBaseResponse<CreateResponse>();
                var post = _mapper.Map<CreateRequest, SEMS.Core.Entities.Post>(request);
                _unitofwork.Posts.Add(post);
                 await _unitofwork.SaveAsync();

                resposne.Data = _mapper.Map<SEMS.Core.Entities.Post, CreateResponse>(post);
                resposne.Result = NodeResult.Ok;
                return resposne;
            }
        }

    }
}
