using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;
using CollegeManagement.Domain.SeedWork;

using System;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.DisenrollmentAggregate
{
    public class Disenrollment : AggregateRoot
    {
        public virtual Student Student { get; protected set; }
        public virtual Course Course { get; protected set; }
        public virtual DateTime DateTime { get; protected set; }
        public virtual Comment Comment { get; protected set; }

        protected Disenrollment()
        {
        }

        public Disenrollment(Student student, Course course, Comment comment)
            : this()
        {
            Student = student;
            Course = course;
            Comment = comment;
            DateTime = DateTime.UtcNow;
        }
    }
}
