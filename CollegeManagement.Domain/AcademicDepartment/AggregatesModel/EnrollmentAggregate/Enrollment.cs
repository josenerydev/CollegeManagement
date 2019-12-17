using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;
using CollegeManagement.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate
{
    public class Enrollment : AggregateRoot
    {
        public virtual Student Student { get; protected set; }
        public virtual Course Course { get; protected set; }
        public virtual Grade Grade { get; protected set; }

        protected Enrollment()
        {
        }

        public Enrollment(Student student, Course course, Grade grade)
            : this()
        {
            Student = student;
            Course = course;
            Grade = grade;
        }

        public virtual void Update(Course course,Grade grade)
        {
            Course = course;
            Grade = grade;
        }
    }
}
