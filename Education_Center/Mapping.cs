using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Domain.Entities;

namespace Education_Center
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Dto_CreateSubject, Subject>().ReverseMap();
            CreateMap<Dto_CreateStudentSubjects, StudentSubjects>().ReverseMap();
            CreateMap<Dto_enrollAttendance, Attendance>().ReverseMap();
            CreateMap<Dto_GetAttendance, Attendance>().ReverseMap();
            CreateMap<Dto_AssignGrades, Grade>().ReverseMap();
            CreateMap<Dto_GradeTypes, GradeTypes>().ReverseMap();
            CreateMap<Dto_ClassScedule, ClassSchedule>().ReverseMap();
            CreateMap<Dto_ClassSessions, ClassSessions>().ReverseMap();
            CreateMap<Dto_SessionAttendance, SessionAttendance>().ReverseMap();
            CreateMap<Dto_SessionAttendance_PerStudent, SessionAttendance>().ReverseMap();
            
        }

    }
}


