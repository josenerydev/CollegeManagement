using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public class Student : AggregateRoot
    {
        private readonly string _name;
        public virtual Name Name => (Name)_name;

        private readonly string _email;
        public virtual Email Email => (Email)_email;

        protected Student()
        {
        }

        public Student(Name name, Email email)
            : this()
        {
            _name = name;
            _email = email;
        }
    }
}
