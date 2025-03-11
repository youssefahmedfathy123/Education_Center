using AutoMapper;
using Education_Center_Contract.Interfaces.Education;
using Education_Center_DbContext;
using Education_Center_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center_Contract.Interfaces.UnitOfWork
{
        public class UnitOfWork : IUnitOfWork
        {

            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapping;

            public IEducation_crud<Subject> Subjects { get; private set; }
            public IEducation_crud<StudentSubjects> StudentSubjects { get; private set; }
            public IEducation_crud<Attendance> Attendances { get; private set; }
            public IEducation_crud<Grade> Grades { get; private set; }

            public IEducation_crud<GradeTypes> GradeTypes { get; private set; }

            public IEducation_crud<ClassSchedule> ClassSchedule { get; private set; }

            public IEducation_crud<ClassSessions> ClassSessions { get; private set; }

            public IEducation_crud<SessionAttendance> SessionAttendance { get; private set; }

        public UnitOfWork(ApplicationDbContext db, IMapper mapping)
            {
                _db = db;
                _mapping = mapping;
                Subjects = new Education_crud<Subject>(_db, _mapping);
                StudentSubjects = new Education_crud<StudentSubjects>(_db, _mapping);
                Attendances = new Education_crud<Attendance>(_db, _mapping);
                Grades = new Education_crud<Grade>(_db, _mapping);
                GradeTypes = new Education_crud<GradeTypes>(_db, _mapping);
                ClassSchedule = new Education_crud<ClassSchedule>(_db, _mapping);
                ClassSessions = new Education_crud<ClassSessions>(_db, _mapping);
                SessionAttendance = new Education_crud<SessionAttendance>(_db, _mapping);
        }

         
        public void Dispose()
            {
                _db.Dispose();
            }

        public async Task<int> Complete()
        {
            return await _db.SaveChangesAsync();
        }
    }

    }
