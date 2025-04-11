using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Contract.Dto.Attendance;
using Education_Center_Contract.Dto.ClassSchedule;
using Education_Center_Contract.Dto.ClassSession;
using Education_Center_Contract.Dto.Grade;
using Education_Center_Contract.Dto.GradeTypes;
using Education_Center_Contract.Dto.SessionAttendance;
using Education_Center_Contract.Dto.StudentSubjects;
using Education_Center_Contract.Dto.Subject;
using Education_Center_Domain.Entities;

namespace Education_Center
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<SubjectCreateDto, Subject>().ReverseMap();
            CreateMap<StudentSubjectsCreateDto, StudentSubjects>().ReverseMap();
            CreateMap<AttendanceCreateDto, Attendance>().ReverseMap();
            CreateMap<AttendanceGetDto, Attendance>().ReverseMap();
            CreateMap<GradesDto, Grade>().ReverseMap();
            CreateMap<GradeTypesDto, GradeTypes>().ReverseMap();
            CreateMap<ClassSceduleDto, ClassSchedule>().ReverseMap();
            CreateMap<ClassSessionsDto, ClassSessions>().ReverseMap();
            CreateMap<SessionAttendanceCreateDto, SessionAttendance>().ReverseMap();
            CreateMap<SessionAttendanceGetDto, SessionAttendance>().ReverseMap();
        }

    }
}


