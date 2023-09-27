using AutoMapper;
using MediatR;
using School.core.Bases;
using School.core.Features.Departments.Queries.Models;
using School.core.Features.Departments.Queries.Results;
using School.service.Abstracts;

namespace School.core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>
    {
        #region Properties
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly ResponseHandler _responseHandler;
        #endregion
        #region Constructor
        public DepartmentQueryHandler(ResponseHandler responseHandler, IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
            _responseHandler = responseHandler;
        }

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetDepartmentById(request.Id);
            if (result==null)
            {
                return _responseHandler.NotFound<GetDepartmentByIdResponse>("Department not found");
            }
            var mapper = _mapper.Map<GetDepartmentByIdResponse>(result);
            return _responseHandler.Success(mapper);
        }
        #endregion
        #region Methods
        #endregion

    }
}
