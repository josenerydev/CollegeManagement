﻿using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;
using CollegeManagement.Domain.SeedWork;

using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.DisenrollmentAggregate
{
    public sealed class DisenrollCommand : ICommand
    {
        public long Id { get; }
        public int EnrollmentNumber { get; }
        public string Comment { get; }

        public DisenrollCommand(long id, int enrollmentNumber, string comment)
        {
            Id = id;
            EnrollmentNumber = enrollmentNumber;
            Comment = comment;
        }

        internal sealed class DisenrollCommandHandler : ICommandHandler<DisenrollCommand>
        {
            private readonly SessionFactory _sessionFactory;

            public DisenrollCommandHandler(SessionFactory sessionFactory)
            {
                _sessionFactory = sessionFactory;
            }

            public Result Handle(DisenrollCommand command)
            {
                var unitOfWork = new UnitOfWork(_sessionFactory);
                var studentRepository = new StudentRepository(unitOfWork);
                Student student = studentRepository.GetById(command.Id);
                if (student == null)
                    return Result.Failure($"No student found for Id {command.Id}");

                if (string.IsNullOrWhiteSpace(command.Comment))
                    return Result.Failure("Disenrollemnt comment is required");

                Enrollment enrollment = student.GetEnrollment(command.EnrollmentNumber);
                if (enrollment == null)
                    return Result.Failure($"No enrollment found with number '{command.EnrollmentNumber}'");

                student.RemoveEnrollment(enrollment, command.Comment);

                unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
