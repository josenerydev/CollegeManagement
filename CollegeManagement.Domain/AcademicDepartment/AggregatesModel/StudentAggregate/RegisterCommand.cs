using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;
using CollegeManagement.Domain.SeedWork;

using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate
{
    public sealed class RegisterCommand : ICommand
    {
        public string Name { get; }
        public string Email { get; }
        public string Course1 { get; }
        public string Course1Grade { get; }
        public string Course2 { get; }
        public string Course2Grade { get; }

        public RegisterCommand(string name, string email, string course1, string course1Grade, string course2, string course2Grade)
        {
            Name = name;
            Email = email;
            Course1 = course1;
            Course1Grade = course1Grade;
            Course2 = course2;
            Course2Grade = course2Grade;
        }

        internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
        {
            private readonly SessionFactory _sessionFactory;
            public RegisterCommandHandler(SessionFactory sessionFactory)
            {
                _sessionFactory = sessionFactory;
            }

            public Result Handle(RegisterCommand command)
            {
                var unitOfWork = new UnitOfWork(_sessionFactory);
                var courseRepository = new CourseRepository(unitOfWork);
                var studentRepository = new StudentRepository(unitOfWork);

                var studentName = Common.Name.Create(command.Name);
                if (studentName.IsFailure)
                    return Result.Failure(studentName.Error);

                var studentEmail = StudentAggregate.Email.Create(command.Email);
                if (studentEmail.IsFailure)
                    return Result.Failure(studentEmail.Error);

                var student = new Student(studentName.Value, studentEmail.Value);

                if (command.Course1 != null && command.Course1Grade != null)
                {
                    Course course = courseRepository.GetByName(command.Course1);
                    var grade = Common.Grade.Get(command.Course1Grade);
                    if (grade.IsFailure)
                        return Result.Failure(grade.Error);

                    student.Enroll(course, grade.Value);
                }

                if (command.Course2 != null && command.Course2Grade != null)
                {
                    Course course = courseRepository.GetByName(command.Course2);
                    var grade = Common.Grade.Get(command.Course2Grade);
                    if (grade.IsFailure)
                        return Result.Failure(grade.Error);

                    student.Enroll(course, grade.Value);
                }

                studentRepository.Save(student);
                unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
