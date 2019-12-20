using CSharpFunctionalExtensions;

using System.Collections.Generic;

namespace CollegeManagement.Domain.AcademicDepartment.AggregatesModel.DisenrollmentAggregate
{
    public class Comment : ValueObject
    {
        public string Value { get; }

        private Comment(string value)
        {
            Value = value;
        }

        public static Result<Comment> Create(Maybe<string> commentOrNothing)
        {
            return commentOrNothing.ToResult("Comment should not be empty")
                .Map(comment => comment.Trim())
                .Ensure(comment => comment != string.Empty, "Comment should not be empty")
                .Ensure(comment => comment.Length <= 200, "Comment is too long")
                .Map(comment => new Comment(comment));
        }

        public static explicit operator Comment(string comment)
        {
            return Create(comment).Value;
        }

        public static implicit operator string(Comment comment)
        {
            return comment.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
