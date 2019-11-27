using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public class Student : AggregateRoot
    {
        public virtual Name Name { get; protected set; }
        public virtual Email Email { get; protected set; }

        protected Student()
        {
        }

        public Student(Name name, Email email)
            : this()
        {
            Name = name;
            Email = email;
        }
    }
}
