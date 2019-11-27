using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.CourseAggregate;

using FluentAssertions;

using Xunit;

namespace CollegeManagement.Domain.Tests.AcademicDepartmentTests
{
    public class CreditsTests
    {
        [Fact]
        public void Credits_is_null_should_return_an_error_message()
        {
            var result = Credits.Create(null);

            result.Error.Should().Be("Credits should not be empty");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Credits_is_less_than_zero_should_return_error_message()
        {
            var result = Credits.Create(-1);

            result.Error.Should().Be("Credits not negative number");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Credits_is_zero_should_return_error_message()
        {
            var result = Credits.Create(0);

            result.Error.Should().Be("Credits not be zero");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Credits_is_greater_than_5_should_return_error_message()
        {
            var result = Credits.Create(6);

            result.Error.Should().Be("Credits not be more than 5");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Credits_is_equal_5_should_return_valid_object()
        {
            var result = Credits.Create(5);
            int credits = result.Value;

            credits.Should().Be(5);
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Credits_explicit_conversition()
        {
            var credits = 5;
            var result = (Credits)credits;

            result.Value.Should().Be(5);
        }

        [Fact]
        public void Credits_implicit_conversition()
        {
            var credits = Credits.Create(3);
            int result = credits.Value;

            result.Should().Be(3);
        }

        [Fact]
        public void Credits_has_same_value()
        {
            var credits1 = Credits.Create(3);
            var credits2 = Credits.Create(3);

            credits1.Should().Be(credits2);
        }

        [Fact]
        public void Credits_has_diferents_values()
        {
            var credits1 = Credits.Create(5);
            var credits2 = Credits.Create(3);

            credits1.Should().NotBe(credits2);
        }
    }
}
