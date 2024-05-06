using BusinessLayer;
using College.Models;
using Microsoft.AspNetCore.Mvc;
using static Utilities.Enums.File;
using Utilities;

namespace College.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        // private readonly ILogger<StudentController> _logger;
        private readonly StudentBll _studentService;

        public StudentController(/*ILogger<StudentController> logger,*/ StudentBll studentService)
        {
            // _logger = logger;
            _studentService = studentService;
        }

        /// <summary>
        /// Lấy sinh viên theo mã số sinh viên
        /// </summary>
        /// <param name="id">Mã số sinh viên</param>
        /// <returns>Sinh viên</returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetById")]
        public Student GetById(int id)
        {
            FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] Start GetById/{id}" });
            FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] _studentService != null? {_studentService != null}" });
            DataLayer.Entities.Student entity = null;
            try
            {
                entity = _studentService.Get(id);
            }
            catch(Exception exception)
            {
                FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] exception = {exception.Message}; stacktrace = {exception.StackTrace}" });
            }

            FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] entity != null? {entity != null}" });
            return new Student { 
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BornDate = entity.BornDate
            };
        }

        /// <summary>
        /// Lấy sinh viên theo họ và tên
        /// </summary>
        /// <param name="firstName">Tên</param>
        /// <param name="lastName">Họ và tên đệm</param>
        /// <returns>Thông tin sinh viên</returns>
        [HttpGet(Name = "GetByName")]
        public Student GetByName(string firstName, string lastName)
        {
            DataLayer.Entities.Student entity = _studentService.GetByFullName(firstName, lastName);
            return new Student
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                BornDate = entity.BornDate
            };
        }

        /// <summary>
        /// Thêm sinh viên mới
        /// </summary>
        /// <param name="student">Thông tin sinh viên</param>
        /// <returns>Mã số sinh viên</returns>
        [HttpPost(Name = "CreateStudent")]
        public ActionResult<Student> CreateStudent([FromBody] Student student)
        {
            DataLayer.Entities.Student entity = new DataLayer.Entities.Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BornDate = student.BornDate
            };

            _studentService.Create(entity);

            return Ok(new
            {
                id = entity.Id
            });
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên
        /// </summary>
        /// <param name="student">Thông tin sinh viên</param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateStudent")]
        public ActionResult<Student> UpdateStudent([FromBody] Student student)
        {
            DataLayer.Entities.Student entity = _studentService.Get(student.Id);
            entity.FirstName = student.FirstName;
            entity.LastName = student.LastName;
            entity.BornDate = student.BornDate;

            _studentService.Update(entity);

            return Ok();
        }

        /// <summary>
        /// Xóa sinh viên
        /// </summary>
        /// <param name="id">Mã số sinh viên</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}", Name = "DeleteStudent")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            _studentService.Delete(id);

            return Ok();
        }
    }
}
