using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
using Education_Center_Domain.Help;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Education_Center.Controllers.Education_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoard_TeacherController : ControllerBase
    {
        //	•	Teachers are assigned to subjects.
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _user; 
        public DashBoard_TeacherController(IUnitOfWork unit, ApplicationDbContext db, UserManager<User> user)
        {
            _unit = unit;
            _db = db;
            _user = user;
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("Create_Subject")]
        public async Task<IActionResult> Create_Subject(Dto_CreateSubject dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");

            var res = await _unit.Subjects.Create<Dto_CreateSubject>(dto);

            return Ok(res);
        }


        //	2.	Attendance
        //	•	Teachers can view attendance for their students.
        [Authorize(Roles = "Teacher")]
        [HttpGet("Get_Attendance")]
        public async Task<IActionResult> Get_Attendance()
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");

            var result = await _unit.Attendances.Read<Dto_GetAttendance>();

            return Ok(result);
        }


        //	3.	Grades
        //	•	Teachers assign grades to students for their subjects.

        [Authorize(Roles = "Teacher")]
        [HttpPost("Assign_Grades")]
        public async Task<IActionResult> Assign_Grades([FromBody]AssignGrades assign)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");

            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Find_Teacher = await _user.FindByNameAsync(name);

            if (Find_Teacher is null)
                return NotFound("User not found!");

            var user = await _user.FindByEmailAsync(assign.StudentEmail);

            var subject = await _db.Subjects.FirstOrDefaultAsync(s => s.Name.ToLower() == assign.SubjectName.ToLower()
              && s.Branch_id == assign.BranchId);

            if (subject is null)
                return NotFound("Subject not found!");


            var Final_result = new Dto_AssignGrades
            {
                Student_id = user.Id,
                Subject_id = subject.Id,
                Teacher_id = Find_Teacher.Id,
                Grade_type_id = assign.GradtypeId,
                _Grade = assign.Grade,
                Comments = assign.Comment
            };

            var result = await _unit.Grades.Create<Dto_AssignGrades>(Final_result);

            return Ok(result);
        }


        //Grade Types
        //•	Teachers can assign different types of grades (e.g., exams, assignments).
        [Authorize(Roles = "Teacher")]
        [HttpPost("AddingGradeTypes")]
        public async Task<IActionResult> AddingGradeTypes(Dto_GradeTypes dto)
        {
            if(!ModelState.IsValid)
                return BadRequest("State not valid!");

            var result = await _unit.GradeTypes.Create<Dto_GradeTypes>(dto);

            return Ok(result);
        }


        //When a session occurs, attendance is recorded per student.
        //•	This allows tracking the number of students present and absent per session.
        [Authorize(Roles = "Teacher")]
        [HttpPost("SessionAttendance")]
        public async Task<IActionResult> SessionAttendance([FromForm]Create_SessionsAttendance created)
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Teacher = await _user.FindByNameAsync(name);

            if (Teacher is null)
                return NotFound("Teacher not found!");

            var user = await _user.FindByNameAsync(created.Student_UserName);
            if (user is null)
                return NotFound("User not found!");

            var dto = new Dto_SessionAttendance
            {
                Session_id = created.Session_id,
                recorded_by = Teacher.Id,
                Status = (created.Status).ToString(),
                Student_id = user.Id
            };

            var Final_result = await _unit.SessionAttendance.Create<Dto_SessionAttendance>(dto);

            return Ok(Final_result);
        }



    }
}

