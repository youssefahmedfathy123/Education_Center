using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
using Education_Center_Domain.Entities;
using Education_Center_Domain.Help;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Education_Center.Controllers.Education_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoard_StudentsController : ControllerBase
    {
        //	•	Students enroll in subjects.
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
        public async Task<IActionResult> EnrollInSubject(CreateStudentSubjects create)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");


            // Email subject branch
            var Find_user = await _user.FindByEmailAsync(create.Email);
            if (Find_user is null)
                return BadRequest("User not found!");


            var Find_branch = _db.Branches.FirstOrDefault(b => b.Name.ToLower() == create.Branch.ToLower());
            if (Find_branch is null)
                return BadRequest("Branch not found!");


            var Find_subject = _db.Subjects.FirstOrDefault(s => s.Name.ToLower() == create.Subject.ToLower()
              && s.Branch_id == Find_branch.Id
            );

            if (Find_subject is null)
                return BadRequest("Subject not found!");


            var dto = new Dto_CreateStudentSubjects
            {
                Student_id = Find_user.Id,
                Subject_id = Find_subject.Id
            };

            var res = await _unit.StudentSubjects.Create<Dto_CreateStudentSubjects>(dto);

            return Ok(res);
        }


        //Student Dashboard
        //	•	Show detailed attendance records (Present, Absent, Late).
        [Authorize(Roles = "Student")]
        [HttpGet("Get_detailed_attendance_ByUser")]
        public async Task<IActionResult> Get_detailed_attendance_ByUser()
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Student = await _user.FindByNameAsync(name);

            if (Student is null)
                return NotFound("Student not found!");

            var sessionAttendance = _db.SessionAttendance.Where(s => s.Student_id == Student.Id).ToList();

            var map = _mapping.Map<List<SessionAttendance>,List<Dto_SessionAttendance_PerStudent>>(sessionAttendance);

            return Ok(map);
        }


        //	•	Display total absences per subject.
        [Authorize(Roles = "Student")]
        [HttpGet("Display_total_absences_perStudent_ByStudent")]
        public async Task<IActionResult> Display_total_absences_perStudent_ByStudent()
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Student = await _user.FindByNameAsync(name);

            if (Student is null)
                return NotFound("Student not found!");

            var sessionAttendance_number = _db.SessionAttendance.Where(s => s.Student_id == Student.Id
                && s.Status == "Present"
            ).ToList().Count();

            if (sessionAttendance_number < 1)
                return Ok("You did not attend any sessions");

            return Ok($"The Total Absences is {sessionAttendance_number}");
        }




        //	•	List all grades by subject and grade type (Exam, Assignment, etc.).
        [Authorize(Roles = "Student")]
        [HttpGet("Display_total_Grades_ByUser")]
        public async Task<IActionResult> Display_total_Grades_ByUser()
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Student = await _user.FindByNameAsync(name);

            if (Student is null)
                return NotFound("Student not found!");

            var Grades = _db.Grades.Where(s => s.Student_id == Student.Id).ToList();


            List<GetGrades> Show = new();

            foreach (var g in Grades)
            {

                var Teacher_userName = await _user.FindByIdAsync(g.Teacher_id);
                var GradeName = await _db.GradeTypes.FirstOrDefaultAsync(f => f.Id == g.Grade_type_id);
                var SubjectName = await _db.Subjects.FirstOrDefaultAsync(f => f.Id == g.Subject_id);

                
                var grade = new GetGrades
                {
                    Teacher_Name = Teacher_userName.Name,
                    Grade_type_Name = GradeName.Name,
                    Subject_Name = SubjectName.Name,
                    _Grade = g._Grade,
                    Comments = g.Comments
                };
                Show.Add(grade);
            }

            return Ok(Show);

        }



        //	•	Show upcoming class sessions with date, time, and subject.
        // calss session is scheduled

        [Authorize(Roles = "Student")]
        [HttpGet("upcoming_class_sessions")]
        public async Task<IActionResult> upcoming_class_sessions()
        {
            var ClassSessions_unComming = _db.ClassSessions.Where(s => s.Status == "Scheduled").ToList();


            var map = _mapping.Map<List<ClassSessions>,List<Dto_ClassSessions>>(ClassSessions_unComming);
            return Ok(map);
        
        }
    }
}


