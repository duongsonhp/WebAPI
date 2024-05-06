using DataLayer.Entities;
using DataLayer.Repository;
using static Utilities.Enums.File;
using Utilities;

namespace BusinessLayer
{
    public class StudentBll
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentBll(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student Get(int id)
        {
            FileUtility.WriteContent(LogFile.ErrorLog, new List<string>() { $"[{DateTime.Now.ToString()}] _studentRepository != null? {_studentRepository != null}" });
            return _studentRepository.Get(id);
        }

        public Student GetByFirstName(string firstName)
        {
            return _studentRepository.Get(student => student.FirstName == firstName);
        }

        public Student GetByLastName(string lastName)
        {
            return _studentRepository.Get(student => student.LastName == lastName);
        }

        public Student GetByFullName(string firstName, string lastName)
        {
            return _studentRepository.Get(student => student.FirstName == firstName && student.LastName == lastName);
        }

        public bool Create(Student student)
        {
            try
            {
                _studentRepository.Add(student);
                
            }
            catch(Exception exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Student student)
        {
            try
            {
                _studentRepository.Update(student);
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                _studentRepository.Delete(id);
            }
            catch (Exception exception)
            {
                return false;
            }

            return true;
        }
    }
}
