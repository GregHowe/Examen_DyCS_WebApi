using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;
using System.Collections.Generic;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class StudentAssembler //CustomerAssembler
    {
        private readonly IMapper _mapper;

        public StudentAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Student FromSignUpDtoToStudent(SignUpDto signUpDto)
        {
            return _mapper.Map<SignUpDto, Student> (signUpDto);
        }

        public Student FromStudentDtoToCustomer(StudentDto studentDto)
        {
            return _mapper.Map<StudentDto, Student>(studentDto);
        }

        public List<StudentDto> toDtoList(List<Student> studentList)
        {
            return _mapper.Map<List<Student>, List< StudentDto>>(studentList);
        }
    }
}