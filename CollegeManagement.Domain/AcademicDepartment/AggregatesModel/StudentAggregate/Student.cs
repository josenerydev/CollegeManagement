using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.DisenrollmentAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate;
using CollegeManagement.Domain.SeedWork;

using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public class Student : AggregateRoot
    {
        private readonly string _name;
        public virtual Name Name => (Name)_name;

        private readonly string _email;
        public virtual Email Email => (Email)_email;

        private readonly IList<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        private readonly IList<Disenrollment> _disenrollments = new List<Disenrollment>();
        public virtual IReadOnlyList<Disenrollment> Disenrollments => _disenrollments.ToList();

        protected Student()
        {
        }

        public Student(Name name, Email email)
            : this()
        {
            _name = name;
            _email = email;
        }

        public virtual Enrollment GetEnrollment(int index)
        {
            if (_enrollments.Count > index)
                return _enrollments[index];

            return null;
        }

        public virtual void RemoveEnrollment(Enrollment enrollment, Comment comment)
        {
            _enrollments.Remove(enrollment);

            var disenrollment = new Disenrollment(enrollment.Student, enrollment.Course, comment);
            _disenrollments.Add(disenrollment);
        }

        public virtual void Enroll(Course course, Grade grade)
        {
            if (_enrollments.Count >= 2)
                throw new Exception("Cannot have more than 2 enrollments");

            var enrollment = new Enrollment(this, course, grade);
            _enrollments.Add(enrollment);
        }
    }
}
