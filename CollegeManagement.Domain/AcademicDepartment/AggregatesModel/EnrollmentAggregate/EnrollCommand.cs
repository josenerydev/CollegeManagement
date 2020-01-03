﻿using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;
using CollegeManagement.Domain.SeedWork;

using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate
{
    public sealed class EnrollCommand : ICommand
    {
        public long Id { get; }
        public string Course { get; }
        public string Grade { get; }

        public EnrollCommand(long id, string course, string grade)
        {
            Id = id;
            Course = course;
            Grade = grade;
        }

        internal sealed class EnrollCommandHandler : ICommandHandler<EnrollCommand>
        {
            private readonly SessionFactory _sessionFactory;

            public EnrollCommandHandler(SessionFactory sessionFactory)
            {
                _sessionFactory = sessionFactory;
            }

            public Result Handle(EnrollCommand command)
            {
                var unitOfWork = new UnitOfWork(_sessionFactory);
                var courseRepository = new CourseRepository(unitOfWork);
                var studentRepository = new StudentRepository(unitOfWork);

                Student student = studentRepository.GetById(command.Id);
                if (student == null)
                    return Result.Failure($"No student found for Id {command.Id}");

                Course course = courseRepository.GetByName(command.Course);
                if (course == null)
                    return Result.Failure($"Course is incorrect: '{command.Course}'");

                var grade = Common.Grade.Get(command.Grade);
                if (grade.IsFailure)
                    return Result.Failure(grade.Error);

                student.Enroll(course, grade.Value);

                unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}