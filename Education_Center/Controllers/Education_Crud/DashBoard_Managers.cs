using Education_Center_Contract.Dto;
using Education_Center_Contract.Interfaces.UnitOfWork;
using Education_Center_DbContext;
using Education_Center_Domain.Enum;
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
        [HttpPost("RecordAttendance")]
        public async Task<IActionResult> RecordAttendance([FromForm]EnrollAttendance record)
        {
            var manager_username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var _manager = await _user.FindByNameAsync(manager_username);

            if (_manager == null)
                return NotFound("Manager Not Found!");

            var student = await _user.FindByEmailAsync(record.Student_Email);

            if (student == null)
                return NotFound("Manager Not Found!");


            var res = new Dto_enrollAttendance
            {
                Status = (record.Status).ToString(),
                Recorded_by = _manager.Id,
                Student_id = student.Id
            };

            var Final_result = await _unit.Attendances.Create<Dto_enrollAttendance>(res);

            return Ok(Final_result);
        }


        //2.	 Schedules 
        //•	Each subject has a schedule defining days and times.
        [Authorize(Roles = "Manager")]
        [HttpPost("CreateSchedule")]
        public async Task<IActionResult> CreateSchedule([FromForm]ClassSchedule schedule)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model not valid!");

            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Manager = await _user.FindByNameAsync(name);

            if (Manager is null)
                return NotFound("Subject not found!");

            var subject = await _db.Subjects.FirstOrDefaultAsync(s => s.Name.ToLower() == schedule.Subject_name.ToLower()
               && s.Branch_id == schedule.Branch_id
            );

            if (subject is null)
                return NotFound("Subject not found!");


            var dto = new Dto_ClassScedule
            {
                Subject_id = subject.Id,
                Branch_id = schedule.Branch_id,
                Teacher_id = Manager.Id,
                Day_of_week = (schedule.Day_of_week).ToString(),
                Start_time = schedule.Start_time,
                End_time = schedule.End_time
            };


            var Final_result = await _unit.ClassSchedule.Create<Dto_ClassScedule>(dto);

            return Ok(Final_result);
        }




        //•	Individual sessions are created based on the schedule.
        //•	A session can be marked as completed or canceled.

        [Authorize(Roles = "Manager")]
        [HttpPost("Session_Status")]
        public async Task<IActionResult> Session_Status([FromForm]Create_ClassSessions created)
        {
            var name = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var Manager = await _user.FindByNameAsync(name);

            if (Manager is null)
                return NotFound("User not found!");

            var dto = new Dto_ClassSessions
            {
                Schedule_id = created.Schedule_id,
                Status = (created.Status).ToString(),
                Date = DateTime.Now
            };

            var Final_result = await _unit.ClassSessions.Create<Dto_ClassSessions>(dto);

            return Ok(Final_result);
        }




    }
}

