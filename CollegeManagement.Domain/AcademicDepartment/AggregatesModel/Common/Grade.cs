using CollegeManagement.Domain.SeedWork;
using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common
{
    public class Grade : AggregateRoot
    {
        public static readonly Grade A = new Grade(0, "A");
        public static readonly Grade B = new Grade(0, "B");
        public static readonly Grade C = new Grade(0, "C");
        public static readonly Grade D = new Grade(0, "D");
        public static readonly Grade F = new Grade(0, "F");

        public virtual string Name { get; protected set; }

        protected Grade()
        {
        }

        private Grade(long id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }

        public static Result<Grade> Get(Maybe<string> name)
        {
            if (name.HasNoValue)
                return Result.Failure<Grade>("Grade name is not specified");

            if (name.Value == A.Name)
                return Result.Ok(A);

            if (name.Value == B.Name)
                return Result.Ok(B);

            if (name.Value == C.Name)
                return Result.Ok(C);

            if (name.Value == D.Name)
                return Result.Ok(D);

            if (name.Value == F.Name)
                return Result.Ok(F);

            return Result.Failure<Grade>($"Grade name is invalid: {name}");
        }
    }
}
