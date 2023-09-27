using AutoMapper;
using MediatR;
using School.core.Bases;
using School.core.Features.Students.Commands.Models;
using School.data.Entities;
using School.service.Abstracts;

namespace School.core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region private members
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);

            if (result == "Success")
            {
                return Created("CreatedSuccessfully");
            }
            else
            {
                return BadRequest<string>("Something went wrong");
            }
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>("Student not found");
            }
            else
            {
                var studentMapper = _mapper.Map(request, student);
                var result = await _studentService.EditAsync(studentMapper);
                if (result == "Success")
                {
                    return Success($"Updated Successfully{request.Id}");
                }
                else
                {
                    return BadRequest<string>("Something went wrong");
                }
            }
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null)
            {
                return NotFound<string>("Student not found");
            }
            else
            {
                var result = await _studentService.DeleteAsync(student);
                if (result == "Success")
                {
                    return Deleted<string>();
                }
                else
                {
                    return BadRequest<string>("Something went wrong");
                }
            }
        }


        #endregion

        #region Methods

        #endregion

    }
}
