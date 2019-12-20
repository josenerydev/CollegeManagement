using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(UnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }
    }
}
