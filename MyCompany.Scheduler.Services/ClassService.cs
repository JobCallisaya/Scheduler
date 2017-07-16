using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Scheduler.Services
{
    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.MyCompany.Scheduler.DataAccess;

    /// <summary>
    /// The Class service.
    /// </summary>
    public class ClassService : BaseService<Class>
    {   
        private IRepository<Student> studentRepository;

        public ClassService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.studentRepository = unitOfWork.GetRepository<Student>();
        }

        public void AddStudentToClass(int classId, int studentId)
        {
            var clase = this.Get(classId);
            var student = this.studentRepository.Get(studentId);
            clase.Students.Add(student);
            student.Classes.Add(clase);
        }

        public List<Student> GetStudents(int classId)
        {
            return this.Get(classId).Students;
        }
    }
}
