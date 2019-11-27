using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.Common;

using FluentAssertions;

using System.Text;

using Xunit;

namespace CollegeManagement.Domain.Tests.AcademicDepartmentTests
{
    public class NameTests
    {
        [Fact]
        public void Name_is_empty_should_return_an_error_message()
        {
            var result = Name.Create("");

            result.Error.Should().Be("Name should not be empty");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Name_is_null_should_return_an_error_message()
        {
            var result = Name.Create(null);

            result.Error.Should().Be("Name should not be empty");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Name_is_too_long_should_return_error_message()
        {
            StringBuilder name = new StringBuilder();
            for (int i = 0; i < 300; i++)
            {
                name.Append('a');
            }

            var result = Name.Create(name.ToString());

            result.Error.Should().Be("Name is too long");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Name_is_valid_should_return_name_valid()
        {
            var result = Name.Create("José Ângelo");
            string name = result.Value;

            name.Should().Be("José Ângelo");
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Checks_if_names_are_same()
        {
            var name1 = Name.Create("José Ângelo");
            var name2 = Name.Create("José Ângelo");

            name1.Should().Be(name2);
        }

        [Fact]
        public void Checks_if_names_are_diferents()
        {
            var name1 = Name.Create("José Ângelo");
            var name2 = Name.Create("Homem-Aranha");

            name1.Should().NotBe(name2);
        }

        [Fact]
        public void Explicit_convertion()
        {
            var name = "José Ângelo";
            var result = (Name)name;

            result.Value.Should().Be("José Ângelo");
        }

        [Fact]
        public void Implicit_convertion()
        {
            var name = Name.Create("José Ângelo");
            string result = name.Value;

            result.Should().Be("José Ângelo");
        }
    }
}
