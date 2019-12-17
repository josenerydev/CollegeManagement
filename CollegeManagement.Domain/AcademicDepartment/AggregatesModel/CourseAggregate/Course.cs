using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate
{
    public class Course : AggregateRoot
    {
        private readonly string _name;
        public virtual Name Name => (Name)_name;

        private readonly int _credits;
        public virtual Credits Credits => (Credits)_credits;

        protected Course()
        {
        }

        public Course(Name name, Credits credits)
        {
            _name = name;
            _credits = credits;
        }
    }
}
