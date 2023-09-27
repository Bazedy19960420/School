using AutoMapper;
using MediatR;
using School.core.Bases;
using School.core.Features.Students.Quries.Models;
using School.core.Features.Students.Quries.Results;
using School.core.Wrapper;
using School.data.Entities;
using School.service.Abstracts;
using System.Linq.Expressions;

namespace School.core.Features.Students.Quries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>
       , IRequestHandler<GetStudentByIdQuery, Response<GetStudentByIdResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region private members
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region constructor
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);

            var result = Success(studentListMapper);
            result.Meta = new { count = studentListMapper.Count };
            return result;
        }

        public async Task<Response<GetStudentByIdResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return NotFound<GetStudentByIdResponse>("Student not found");
            var studentMapper = _mapper.Map<GetStudentByIdResponse>(student);
            return Success(studentMapper);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Phone, e.Department.DName);
            //var queryable = _studentService.GetStudentsQueryable();
            var FilteredQueryable = _studentService.FilterStudentPaginatedQueryable(request.OrderBy, request.Search);
            var paginatedList = await FilteredQueryable.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new { count = paginatedList.Data.Count };
            return paginatedList;
        }
    }
}
