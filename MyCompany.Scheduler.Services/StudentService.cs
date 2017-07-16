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
    /// The student service.
    /// </summary>
    public class StudentService : BaseService<Student>
    {
        public StudentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {   
        }

        public List<Class> GetClasses(int studentId)
        {
            return this.Get(studentId).Classes;
        }
    }
}
