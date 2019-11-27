using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate
{
    public class Course : AggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual Credits Credits { get; protected set; }
        protected Course()
        {
        }

        public Course(Name name, Credits credits)
        {
            Name = name;
            Credits = credits;
        }
    }
}
