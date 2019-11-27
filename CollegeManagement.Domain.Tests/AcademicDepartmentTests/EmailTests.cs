using CollegeManagement.Domain.AcademicDepartment.AggregatesModel.StudentAggregate;

using FluentAssertions;

using System.Text;

using Xunit;

namespace CollegeManagement.Domain.Tests.AcademicDepartmentTests
{
    public class EmailTests
    {
        [Fact]
        public void Email_is_empty_should_return_an_error_message()
        {
            var result = Email.Create("");

            result.Error.Should().Be("Email should not be empty");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Email_is_null_should_return_an_error_message()
        {
            var result = Email.Create(null);

            result.Error.Should().Be("Email should not be empty");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Email_is_too_long_should_return_error_message()
        {
            StringBuilder email = new StringBuilder();
            for (int i = 0; i < 300; i++)
            {
                email.Append('a');
            }

            var result = Email.Create(email.ToString());

            result.Error.Should().Be("Email is too long");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Email_is_invalid_should_return_error_message()
        {
            var result = Email.Create("jose.nerycom.br");

            result.Error.Should().Be("Email is invalid");
            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Email_is_valid_should_return_email_valid()
        {
            var result = Email.Create("jose.nery@guiando.com.br");
            string email = result.Value;

            email.Should().Be("jose.nery@guiando.com.br");
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Checks_if_emails_are_same()
        {
            var email1 = Email.Create("jose.nery@guiando.com.br");
            var email2 = Email.Create("jose.nery@guiando.com.br");

            email1.Should().Be(email2);
        }

        [Fact]
        public void Checks_if_emails_are_diferents()
        {
            var email1 = Email.Create("jose.nery@guiando.com.br");
            var email2 = Email.Create("contato@guiando.com.br");

            email1.Should().NotBe(email2);
        }

        [Fact]
        public void Explicit_convertion()
        {
            var email = "jose@gmail.com";
            var result = (Email)email;

            result.Value.Should().Be("jose@gmail.com");
        }

        [Fact]
        public void Implicit_convertion()
        {
            var email = Email.Create("jose@gmail.com");
            string result = email.Value;

            result.Should().Be("jose@gmail.com");
        }
    }
}
