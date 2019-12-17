using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common
{
    public class Grade : AggregateRoot
    {
        public static readonly Grade A = new Grade(0, "A");
        public static readonly Grade B = new Grade(0, "B");
        public static readonly Grade C = new Grade(0, "C");
        public static readonly Grade D = new Grade(0, "D");
        public static readonly Grade F = new Grade(0, "F");

        public virtual string Name { get; }

        protected Grade()
        {
        }

        private Grade(long id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
