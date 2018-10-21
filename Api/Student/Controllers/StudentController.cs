using Microsoft.AspNetCore.Mvc;
using EnterprisePatterns.Api.Common.Application;
using EnterprisePatterns.Api.Customers.Domain.Repository;
using EnterprisePatterns.Api.Customers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using EnterprisePatterns.Api.Common.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Dto;
using EnterprisePatterns.Api.Customers.Application.Assembler;
using EnterprisePatterns.Api.Projects;
using EnterprisePatterns.Api.Projects.Domain.Repository;
using Common.Application;
using EnterprisePatterns.Api.Common.Application.Enum;
using EnterprisePatterns.Api.Common.Domain.Specification;
using EnterprisePatterns.Api.Customers.Infrastructure.Persistence.NHibernate.Specification;

namespace EnterprisePatterns.Api.Controllers
{
    [Route("v1/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly StudentAssembler _studentAssembler;
        private readonly ProjectAssembler _projectAssembler;


        public StudentController(IUnitOfWork unitOfWork,
            IStudentRepository studentRepository,

            IProjectRepository projectRepository,
            StudentAssembler studentAssembler,
            ProjectAssembler projectAssembler)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentRepository;
            _projectRepository = projectRepository;
            _studentAssembler = studentAssembler;
            _projectAssembler = projectAssembler;
        }

        [HttpGet]
        public IActionResult Students([FromQuery] int page = 0, [FromQuery] int size = 5, [FromQuery] bool peruvianOnly = false)
        {
            bool uowStatus = false;
            try
            {
                Specification<Student> specification = GetStudentSpecification(peruvianOnly);
                uowStatus = _unitOfWork.BeginTransaction();
                List<Student> Students = _studentRepository.GetList(specification, page, size);
                _unitOfWork.Commit(uowStatus);
                List<StudentDto> customersDto = _studentAssembler.toDtoList(Students);
                return StatusCode(StatusCodes.Status200OK, customersDto);
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }

        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] SignUpDto signUpDto)
        {
            Notification notification = new Notification();
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();

                Student student = _studentAssembler.FromSignUpDtoToStudent(signUpDto);
                notification = student.validateForSave();

                if (notification.hasErrors())
                {
                    return StatusCode(StatusCodes.Status400BadRequest, notification.ToString());
                }

                _studentRepository.Create(student);

                Project project = _projectAssembler.FromSignUpDtoToProject(signUpDto);

                /*Special Case Patternn*/
                var projectGet = ExistProject(project);
                if (!string.IsNullOrEmpty(projectGet.ProjectName))
                {

                    project.Student = student;
                    /*Null Object Pattern*/
                    var calc_NumberDaysProject = new calc_NumberDaysProject();
                    project.NumberDaysProject = calc_NumberDaysProject.getNumberDaysProject(project.NumberDaysProject).GetNumberProjectDays();
                    /*-----------------------------*/

                    _projectRepository.Create(project);
                }

                _unitOfWork.Commit(uowStatus);

                var message = "Customer, user and project created!";
                KipubitRabbitMQ.SendMessage(message);

                return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto(message));
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                Console.WriteLine(ex.StackTrace);
                var message = "Internal Server Error";
                KipubitRabbitMQ.SendMessage(message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto(message));

            }
        }

        private IProject ExistProject(IProject project)
        {
            if (project != null)
            {
                return project;
            }
            else
            {
                return new NotFound_Project();
            }
        }

        class calc_NumberDaysProject
        {
            public INumberDaysProject getNumberDaysProject(int numberDays)
            {
                INumberDaysProject numberDaysProject = Null_NumberDaysProject.Instance;
                if (numberDays > 0)
                {
                    numberDaysProject = new NumberDaysProject();
                }
                return numberDaysProject;
            }
        }

        private Specification<Student> GetStudentSpecification(bool peruvianOnly)
        {
            Specification<Student> specification = Specification<Student>.All;

            if (peruvianOnly)
                specification = specification.And(new PeruvianStudentsOnlySpecification());

            return specification;
        }

    }
}