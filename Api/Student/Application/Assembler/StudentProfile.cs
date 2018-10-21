using AutoMapper;
using EnterprisePatterns.Api.Customers.Application.Dto;

namespace EnterprisePatterns.Api.Customers.Application.Assembler
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Nombre, x => x.MapFrom(src => src.Nombre)
                );

            CreateMap<StudentDto, Student>()
                .ForMember(
                    dest => dest.Nombre,
                    x => x.MapFrom(src => src.Nombre)
                );
            CreateMap<SignUpDto, Student>()
                .ForMember(
                    dest => dest.Nombre,
                    x => x.MapFrom(src => src.Nombre)
                );


        }
    }
}
