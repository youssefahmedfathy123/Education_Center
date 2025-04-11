using Education_Center_Contract.Dto.Attendance;
using Education_Center_Contract.Dto.ClassSchedule;
using Education_Center_Contract.Dto.ClassSession;
using Education_Center_Contract.Dto.Subject;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
using Education_Center_Domain.Enum;
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
    public class DashBoard_ManagersController : ControllerBase
    {

        //	•	The center manager records student attendance.

        private readonly UserManager<User> _user;
        private readonly IUnitOfWork _unit;
        private readonly ApplicationDbContext _db;
        public DashBoard_ManagersController(UserManager<User> user, IUnitOfWork unit,ApplicationDbContext db)
        {
            _user = user;
            _unit = unit;
            _db = db;
        }


        [Authorize(Roles ="Manager")]
        [HttpPost("RecordAttendance/{StudentId}")]
        public async Task<IActionResult> RecordAttendance([FromForm] AttendanceCreateDto record,string StudentId)
        {

            record.Student_id = StudentId;
            var Final_result = await _unit.Attendances.Create(record);

            return Ok(Final_result);
        }


        [Authorize(Roles = "Manager")]
        [HttpPost("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromForm]ClassSceduleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid!");

            var teacher = await _user.FindByIdAsync(dto.Teacher_id);
            if (teacher is null) return NotFound("Teacher not found!");


        var subject = await _db.Subjects.FirstOrDefaultAsync(s => s.Id == dto.Subject_id
               && s.Branch_id == dto.Branch_id);
            if (subject is null)
                return NotFound("Subject not found!");


            var Final_result = await _unit.ClassSchedule.Create(dto);

            return Ok(Final_result);
        }


        [Authorize(Roles = "Manager")]
        [HttpPost("Session_Status/{Schedule_id}")]
        public async Task<IActionResult> Session_Status([FromForm]ClassSessionsDto dto,int Schedule_id)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid!");

            dto.Schedule_id = Schedule_id;
            var Final_result = await _unit.ClassSessions.Create(dto);

            return Ok(Final_result);
        }



        [Authorize(Roles = "Manager")]
        [HttpPost("CreateSubject/{branchId}")]
        public async Task<IActionResult> CreateSubject([FromForm] SubjectCreateDto dto,int branchId)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid!");

            dto.Branch_id = branchId;
            var result = await _unit.Subjects.Create(dto);

            return Ok(result);
        }



    }
}


