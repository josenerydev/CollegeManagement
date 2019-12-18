using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate
{
    public class Credits : ValueObject
    {
        public int Value { get; }

        private Credits(int? value)
        {
            Value = value.Value;
        }

        public static Result<Credits> Create(Maybe<int?> creditsOrNothing)
        {
            return creditsOrNothing.ToResult("Credits should not be empty")
                .Ensure(credits => credits != 0, "Credits not be zero")
                .Ensure(credits => credits > 0, "Credits not negative number")
                .Ensure(credits => credits <= 5, "Credits not be more than 5")
                .Map(credits => new Credits(credits));
        }

        public static explicit operator Credits(int credits)
        {
            return Create(credits).Value;
        }

        public static implicit operator int(Credits credits)
        {
            return credits.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}