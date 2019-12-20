using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;
using CollegeManagement.Domain.SeedWork;

using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.EnrollmentAggregate
{
    public sealed class TransferCommand : ICommand
    {
        public long Id { get; }
        public int EnrollmentNumber { get; }
        public string Course { get; }
        public string Grade { get; }

        public TransferCommand(long id, int enrollmentNumber, string course, string grade)
        {
            Id = id;
            EnrollmentNumber = enrollmentNumber;
            Course = course;
            Grade = grade;
        }

        internal sealed class TransferCommandHandler : ICommandHandler<TransferCommand>
        {
            private readonly SessionFactory _sessionFactory;

            public TransferCommandHandler(SessionFactory sessionFactory)
            {
                _sessionFactory = sessionFactory;
            }

            public Result Handle(TransferCommand command)
            {
                var unitOfWork = new UnitOfWork(_sessionFactory);
                var courseRepository = new CourseRepository(unitOfWork);
                var studentRepository = new StudentRepository(unitOfWork);
                Student student = studentRepository.GetById(command.Id);
                if (student == null)
                    return Result.Failure($"No student found with Id '{command.Id}'");

                Course course = courseRepository.GetByName(command.Course);
                if (course == null)
                    return Result.Failure($"Course is incorrect: '{command.Course}'");

                Result<Grade> gradeResult = Common.Grade.Get(command.Grade);
                if (gradeResult.IsFailure)
                    return Result.Failure(gradeResult.Error);

                Enrollment enrollment = student.GetEnrollment(command.EnrollmentNumber);
                if (enrollment == null)
                    return Result.Failure($"No enrollment found with number '{command.EnrollmentNumber}'");

                enrollment.Update(course, gradeResult.Value);

                unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
