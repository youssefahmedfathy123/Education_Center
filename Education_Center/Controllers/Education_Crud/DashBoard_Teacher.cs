using AutoMapper;
using Education_Center_Contract.Dto;
using Education_Center_Contract.Dto.Attendance;
using Education_Center_Contract.Dto.Grade;
using Education_Center_Contract.Dto.GradeTypes;
using Education_Center_Contract.Dto.SessionAttendance;
using Education_Center_Contract.Dto.Subject;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
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
        [HttpPost("Create_Subject/{branchId}")]
        public async Task<IActionResult> Create_Subject([FromForm]SubjectCreateDto dto,int branchId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");

            dto.Branch_id = branchId;
            var res = await _unit.Subjects.Create(dto);

            return Ok(res);
        }


        [Authorize(Roles = "Teacher")]
        [HttpGet("Get_Attendance")]
        public async Task<IActionResult> Get_Attendance()
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");

            var result = await _unit.Attendances.Read<AttendanceGetDto>();

            return Ok(result);
        }


        [Authorize(Roles = "Teacher")]
        [HttpPost("Assign_Grades/{SubjectId}/{Grade_type_id}/{Student_id}")]
        public async Task<IActionResult> Assign_Grades([FromForm]GradesDto dto,int SubjectId,int Grade_type_id,string Student_id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not Valid!");


            var user = await _user.FindByIdAsync(Student_id);
            if (user is null) return NotFound("User not found!");

            var gradeType = await _db.GradeTypes.FirstOrDefaultAsync(f => f.Id == Grade_type_id);
            if (gradeType is null) return NotFound("Grade type not found!");

            var subject = await _db.Subjects.FirstOrDefaultAsync(s => s.Id == SubjectId
              && s.Branch_id == user.Branch_id);

            if (subject is null)
                return NotFound("Subject not found!");


            dto.Subject_id = subject.Id;
            dto.Student_id = user.Id;
            dto.Grade_type_id = gradeType.Id;

            var result = await _unit.Grades.Create(dto);

            return Ok(result);
        }


        [Authorize(Roles = "Teacher")]
        [HttpPost("AddingGradeTypes")]
        public async Task<IActionResult> AddingGradeTypes([FromForm]GradeTypesDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest("State not valid!");

            var result = await _unit.GradeTypes.Create(dto);

            return Ok(result);
        }


        [Authorize(Roles = "Teacher")]
        [HttpPost("SessionAttendance/{Session_id}/{Student_id}")]
        public async Task<IActionResult> SessionAttendance([FromForm] SessionAttendanceCreateDto dto,string Student_id,int Session_id)
        {

         var user = await _user.FindByIdAsync(Student_id);
            if (user is null)
                return NotFound("User not found!");

           var Class =  await _db.ClassSessions.FindAsync(Session_id);

            if (Class is null)
                return NotFound("Class not found!");

            dto.Session_id = Session_id;
            dto.Student_id = Student_id;

            var Final_result = await _unit.SessionAttendance.Create(dto);

            return Ok(Final_result);
        }



    }
}


