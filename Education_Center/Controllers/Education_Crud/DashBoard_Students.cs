using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Contract.Dto.ClassSession;
using Education_Center_Contract.Dto.SessionAttendance;
using Education_Center_Contract.Dto.StudentSubjects;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
using Education_Center_Domain.Entities;
using Education_Center_Domain.Enum;
using Education_Center_Domain.Help;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Education_Center.Controllers.Education_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoard_StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _user;
        private readonly IMapper _mapping;
        public DashBoard_StudentsController(IUnitOfWork unit, ApplicationDbContext db, UserManager<User> user, IMapper mapping)
        {
            _unit = unit;
            _db = db;
            _user = user;
            _mapping = mapping;
        }



        [Authorize(Roles = "Student")]
        [HttpPost("EnrollInSubject")]
        public async Task<IActionResult> EnrollInSubject([FromForm]EnrollSubject enroll)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");


            var Find_user = await _user.FindByEmailAsync(enroll.Email); 
            if(Find_user is null)
                return NotFound("User not found!");   

            var Find_subject = _db.Subjects.FirstOrDefault(s => s.Name == enroll.SubjectName
                && s.Branch_id == Find_user.Branch_id);

            if (Find_subject is null) return NotFound("Subject not found!");

            var dto = new StudentSubjectsCreateDto
            {
                Student_id = Find_user.Id,
                Subject_id = Find_subject.Id,
                BranchId = Find_user.Branch_id,
                UserName = Find_user.UserName
            };



            var res = await _unit.StudentSubjects.Create(dto);

            return Ok(res);
        }


        [Authorize(Roles = "Student")]
        [HttpGet("Get_detailed_attendance_ByUser/{StudentId}")]
        public async Task<IActionResult> Get_detailed_attendance_ByUser(string StudentId)
        {
            var sessionAttendance = _db.SessionAttendance.Where(s => s.Student_id == StudentId).ToList();

            var MyList = new List<DetailedAttendanceInfo_User>();

            foreach (var item in sessionAttendance)
            {
                var sessionId = item.Session_id;
                var FindId = await _db.ClassSessions.FirstOrDefaultAsync(f => f.Id == sessionId);
                var schedualRecord = await _db.ClassSchedules.FirstOrDefaultAsync(f => f.Id == FindId.Schedule_id);
                var subjectRecord = await _db.Subjects.FirstOrDefaultAsync(f => f.Id == schedualRecord.Subject_id);

                var x = new DetailedAttendanceInfo_User
                {
                    SubjectName = subjectRecord.Name.GetDisplayName(),
                    Day = schedualRecord.Day_of_week.GetDisplayName(),
                    StartTime = schedualRecord.Start_time,
                    FinishingTime = schedualRecord.End_time,
                    Status = item.Status.GetDisplayName()
                };

                MyList.Add(x);
            }
            return Ok(MyList);

        }


        [Authorize(Roles = "Student")]
        [HttpGet("Display_total_absences_perStudent_ByStudent/{StudentId}")]
        public async Task<IActionResult> Display_total_absences_perStudent_ByStudent(string StudentId)
        {

            var sessionAttendance_number = _db.SessionAttendance.Where(s => s.Student_id == StudentId
                && s.Status == Status_Attendence.Present
              ).ToList().Count();


            if (sessionAttendance_number < 1)
                return Ok("You did not attend any sessions");

            return Ok($"The Total Absences is {sessionAttendance_number}");
        }


        [Authorize(Roles = "Student")]
        [HttpGet("Display_total_Grades_ByUser/{StudentId}")]
        public async Task<IActionResult> Display_total_Grades_ByUser(string StudentId)
        {

            var Grades = _db.Grades.Where(s => s.Student_id == StudentId).ToList();


            List<GetGrades> Mylist = new();

            foreach (var g in Grades)
            {

                var Grade = await _db.GradeTypes.FirstOrDefaultAsync(f => f.Id == g.Grade_type_id);
                var Subject = await _db.Subjects.FirstOrDefaultAsync(f => f.Id == g.Subject_id);

                
                var grade = new GetGrades
                {
                    GradetypeName = Grade.Name,
                    SubjectName = Subject.Name.GetDisplayName(),
                    Grade = g._Grade,
                    Comments = g.Comments
                };
                Mylist.Add(grade);
            }

            return Ok(Mylist);

        }


        [Authorize(Roles = "Student")]
        [HttpGet("upcoming_class_sessions")]
        public async Task<IActionResult> Upcoming_class_sessions()
        {
            var ClassSessions_unComming = _db.ClassSessions.Where(s => s.Status == Status_ClassSessions.Completed).ToList();
            if (ClassSessions_unComming.Count < 1) return NotFound();

            

            var MyList = new List<ClassSessionsUnComming>();
            foreach (var item in ClassSessions_unComming)
            {
                var schedual = await _db.ClassSchedules.FirstOrDefaultAsync(f => f.Id == item.Schedule_id);
                var subject = await _db.Subjects.FirstOrDefaultAsync(f => f.Id == schedual.Subject_id);

                var list = new ClassSessionsUnComming
                {
                    SubjectName = subject.Name.GetDisplayName(),
                    Day = schedual.Day_of_week.GetDisplayName(),
                    StartTime = schedual.Start_time,
                    FinishingTime = schedual.End_time,
                    Date = item.Date,
                };
                MyList.Add(list);
            }

            return Ok(MyList);

        }
    }
}



