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

        private readonly string _comment;
        public virtual Comment Comment => (Comment)_comment;

        protected Disenrollment()
        {
        }

        public Disenrollment(Student student, Course course, Comment comment)
            : this()
        {
            Student = student;
            Course = course;
            _comment = comment;
            DateTime = DateTime.UtcNow;
        }
    }
}
