using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common
{
    public class Name : ValueObject
    {
        public string Value { get; }

        private Name(string value)
        {
            Value = value;
        }

        public static Result<Name> Create(Maybe<string> nameOrNothing)
        {
            return nameOrNothing.ToResult("Name should not be empty")
                .Map(name => name.Trim())
                .Ensure(name => name != string.Empty, "Name should not be empty")
                .Ensure(name => name.Length <= 200, "Name is too long")
                .Map(name => new Name(name));
        }

        public static explicit operator Name(string name)
        {
            return Create(name).Value;
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
